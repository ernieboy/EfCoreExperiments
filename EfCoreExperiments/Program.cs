using EfCoreExperiments.Models;
using EfCoreExperiments.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfCoreExperiments
{
    class Program
    {

        private const string AppleCardId = "3caefd2957a2407abb17b773b6aa7881";

        static async Task Main(string[] args)
        {
            using (var context = new PersistenceContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            try
            {
                await StoreGiftCard();
                await UpdateData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        static async Task StoreGiftCard()
        {
            var giftCards = new List<GiftCard>
            {
                new GiftCard(Guid.NewGuid(), "Tesco", ExpirationDate.Create(DateTime.MaxValue).Value),
                new GiftCard(Guid.Parse(AppleCardId), "Apple", ExpirationDate.Create(DateTime.MaxValue).Value),
                new GiftCard(Guid.NewGuid(), "Marks And Spencer", ExpirationDate.Create(DateTime.MaxValue).Value)
            };

            using (var context = new PersistenceContext())
            {
                await context.GiftCards.AddRangeAsync(giftCards);
                await context.SaveChanges();
            }
        }


        static async Task UpdateData()
        {
            using (var context = new PersistenceContext())
            {
                var appleCard = await context.GiftCards.SingleAsync(i => i.Id == Guid.Parse(AppleCardId));
                appleCard.SetProviderName("Apple Store Gift Card");

                context.Entry(appleCard.ExpiryDate).State = EntityState.Detached;
                appleCard.SetExpirationDate(ExpirationDate.Create(DateTime.UtcNow.AddMonths(2)).Value);
                context.Entry(appleCard.ExpiryDate).State = EntityState.Modified;

                await context.SaveChanges();
            }
        }

        static async Task<GiftCard> FindGiftCardById(Guid id)
        {
            using (var context = new PersistenceContext())
            {
                var giftCard = await context.GiftCards.SingleAsync(i => i.Id == Guid.Parse(AppleCardId));
                
                return giftCard;
            }
        }
    }
}
