using MyWebServer.Http;
using MyWebServer.Controllers;
using BattleCards.ViewModels.Cards;
using BattleCards.Services;
using BattleCards.Data;
using System.Linq;
using BattleCards.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CardsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCardFormModel model)
        {
            var errors = this.validator.ValidateCard(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var card = new Card
            {
                Name = model.Name,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                ImageUrl = model.Image,
                Description = model.Description,
            };

            this.data.Cards.Add(card);
            this.data.SaveChanges();

            var userCard = new UserCard
            {
                Card = card,
                UserId = this.User.Id
            };

            this.data.UserCards.Add(userCard);
            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.data.Cards
                .Select(c => new CardListingModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Keyword = c.Keyword,
                    Attack = c.Attack,
                    Health = c.Health,
                    Image = c.ImageUrl,
                    Description = c.Description
                })
                .ToList();

            return View(cards);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var usersCardsCollection = this.data.UserCards
                .Where(uc => uc.UserId == this.User.Id)
                .Select(uc => new CardListingModel
                {
                    Id = uc.CardId,
                    Name = uc.Card.Name,
                    Keyword = uc.Card.Keyword,
                    Image = uc.Card.ImageUrl,
                    Health = uc.Card.Health,
                    Attack = uc.Card.Attack,
                    Description = uc.Card.Description
                })
                .ToList();

            return View(usersCardsCollection);
        }

        [Authorize]
        public HttpResponse AddToCollection(string cardId)
        {
            var currentUser = this.data.Users
                .Include(uc => uc.UserCard)
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            if (currentUser.UserCard.Any(c => c.CardId == cardId))
            {
                return Redirect("/Cards/All");
            }

            currentUser.UserCard.Add(new UserCard
            {
                CardId = cardId
            });

            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(string cardId)
        {
            var currentUser = this.data.Users
                .Include(uc => uc.UserCard)
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            if (!currentUser.UserCard.Any(c => c.CardId == cardId))
            {
                return Error("User does not own the card.");
            }

            var currentCard = this.data.UserCards
                .Where(c => c.CardId == cardId && c.UserId == this.User.Id)
                .FirstOrDefault();

            currentUser.UserCard.Remove(currentCard);

            this.data.SaveChanges();

            return Redirect("/Cards/Collection");
        }
    }
}
