using System;

namespace EfCoreExperiments.Models
{
    public class GiftCard : IEntity
    {
        protected GiftCard()
        {
        }

        public GiftCard(Guid id, string providerName, ExpirationDate expiryDate)
        {
            if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            Id = id ;
            ProviderName = providerName ?? throw new ArgumentNullException(nameof(providerName));
            ExpiryDate = expiryDate;
        }

        public Guid Id { get; set; }

        public string ProviderName { get; set; }    

        public void SetProviderName(string newName)
        {
            ProviderName = newName;
        }

        public ExpirationDate ExpiryDate { get; protected set; }  

        public void SetExpirationDate(ExpirationDate date)
        {
            ExpiryDate = date;
        }
    }
}
