using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardVaiVoa.Models;
using CardVaiVoa.RuleDomain;

namespace CardVaiVoa.Repository
{
    public class UserCardRepositoy
    {
        private Context _context;
        private CreateCard _createCard;
        public UserCardRepositoy(Context context, CreateCard createCard)
        {
            _context = context;
            _createCard = createCard;
        }
        public UserCard InsertUserCard(int id)
        {
            string resultCreateCard = _createCard.CreateCards();
            var userCard = new UserCard()
            {
                NumberCard = resultCreateCard,
                KeyId = id
            };
            _context.UserCards.Add(userCard);
            _context.SaveChanges();
            return userCard;

        }
        public List<UserCard> ListForId(int id)
        {
            var userCards = _context.UserCards
                    .Where(u => u.KeyId == id) 
                    .ToList();
            return userCards;
        }
    }
}
