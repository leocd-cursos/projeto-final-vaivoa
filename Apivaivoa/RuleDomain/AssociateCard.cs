using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardVaiVoa.Models;
using CardVaiVoa.Repository;



namespace CardVaiVoa.RuleDomain
{
    
    public class AssociateCard
    {
        private Context _context;
        private UserRepository _userRepository;
        private UserCardRepositoy _userCardRepository;
        private CreateCard _createCard;

        public AssociateCard(Context context, UserRepository userRepository, CreateCard createCard, UserCardRepositoy userCardRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _userCardRepository = userCardRepository;
            _createCard = createCard;
        }
        public UserCard CreateAndAssociateCard(string email)
        {
            User resultRepository = _userRepository.GetUserForEmail(email);
            UserCard resultCreateCard = _userCardRepository.InsertUserCard(resultRepository.Id);
            return resultCreateCard;

        }
    }
}
