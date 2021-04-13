# run unit tests and gather coverage information
$args = "test FairMark.Tests --logger=trx;LogFileName=TestResults.trx"
$filter = "+[*]* -[*Test*]* -[*]MdlpApiClient.Xsd*"
OpenCover.Console.exe -returntargetcode -register:administrator -target:dotnet.exe "-targetargs:$args" "-filter:$filter" -output:FairMarkCoverage.xml
$exit = $lastexitcode

# upload reports to the codecov.io server
codecov -t "c01ca799-5c1f-4647-9743-7d6e8b3fb0f8" -f FairMarkCoverage.xml 

# convert trx reports to JUnit format so Gitlab can parse them
trx2junit FairMark.Tests\TestResults\TestResults.trx
#& "$PSScriptRoot\TestReportPrefix.ps1" -inputFileName FairMark.Tests\TestResults\TestResults.xml -outputFileName FairMark.Tests\TestResults\TestResults.xml -prefix "Normal."

# make sure we don't fail on REST methods that need long timeouts
Wait-Event -Timeout 20

# return dotnet test exit code
if (($exit + $exit2) -ne 0)
{
	exit ($exit + $exit2)
}
