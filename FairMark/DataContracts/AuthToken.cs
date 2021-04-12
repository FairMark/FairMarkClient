namespace FairMark.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Fair Mark API authentication token.
    /// True Api 1.5.2. Получение ключа сессии при единой аутентификации
    /// </summary>
    [DataContract]
    public class AuthToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthToken"/>.
        /// </summary>
        public AuthToken()
        {
            // make sure we don't expire prematurely
            CreationDate = DateTime.Now.AddSeconds(-30);
        }

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        [IgnoreDataMember]
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// Gets the expiration date.
        /// </summary>
        [IgnoreDataMember]
        public DateTime ExpirationDate
        {
            get { return CreationDate.AddMinutes(LifeTime); }
        }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        [DataMember(Name = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token lifetime, in minutes.
        /// </summary>
        [IgnoreDataMember]
        public int LifeTime { get; } = (int)TimeSpan.FromHours(10).TotalMinutes;
    }
}
