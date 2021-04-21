@echo off
:: install the tool using:
:: dotnet tool install -g dotnet-xscgen

xscgen ON_NSCHFDOPPOK_1_997_02_05_01_01.xsd -n ""=FairMark.Xsd.ON_NSCHFDOPPOK -sf

xscgen ON_NSCHFDOPPR_1_997_01_05_01_01.xsd -n ""=FairMark.Xsd.ON_NSCHFDOPPR -sf
