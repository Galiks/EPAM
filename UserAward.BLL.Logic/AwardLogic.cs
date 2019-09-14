using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using UserAward.BLL.Interface;
using UserAward.DAL.Interface;

namespace UserAward.BLL.Logic
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public bool AddAward(string title, string description, byte[] awardImage)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var newAward = new Award { IdAward = SetIdAward(), Title = title, Description = description, AwardImage = awardImage };

                _awardDao.AddAward(newAward);

                return true;

            }
            else
            {
                throw new ArgumentNullException($"Title is null");
                //return false;
            }
        }

        public bool DeleteAward(string id)
        {
            if (int.TryParse(id, out int awardId))
            {
                if (GetAwardById(id) != null)
                {
                    _awardDao.DeleteAward(awardId);

                    return true;
                }
                else
                {
                    //Console.WriteLine($"DB has no information");
                    throw new NullReferenceException($"DB has no information");
                    //return false;
                }
            }
            else
            {
                //Console.WriteLine($"Incorrect ID");
                throw new ArgumentException($"Incorrect ID");
                //return false;
            }
        }

        public Award GetAwardById(string id)
        {
            if (int.TryParse(id, out int awardId))
            {
                return _awardDao.GetAwardById(awardId);
            }
            else
            {
                throw new ArgumentException("Award's ID is not number");
                //return null;
            }
        }

        public IEnumerable<Award> GetAwardByLetter(string letter)
        {
            if (char.TryParse(letter, out char awardLetter))
            {
                return _awardDao.GetAwardByLetter(awardLetter).ToList();
            }
            else
            {
                throw new ArgumentException($"Incorrect Letter");
                //Console.WriteLine($"Incorrect Letter");
                //return null;
            }
        }

        public IEnumerable<Award> GetAwardByTitle(string title)
        {
            return _awardDao.GetAwardByTitle(title).ToList();
        }

        public IEnumerable<Award> GetAwardByWord(string word)
        {
            return _awardDao.GetAwardByWord(word);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _awardDao.GetAwards().ToList();
        }

        //Добавить проверку на существование награды!
        public bool UpdateAward(string id, string title, string description, byte[] awardImage)
        {

            if (!string.IsNullOrEmpty(title))
            {
                if (int.TryParse(id, out int awardId))
                {
                    if (GetAwardById(id) != null)
                    {
                        Award award = new Award { IdAward = SetIdAward(), Title = title, Description = description, AwardImage = awardImage };

                        _awardDao.UpdateAward(awardId, award);

                        return true;

                    }
                    else
                    {
                        throw new NullReferenceException($"Award does not exists");
                        //return false;
                    }
                }
                else
                {
                    throw new ArgumentException($"Incorrect ID");
                    //Console.WriteLine($"Incorrect ID");
                    //return false;
                }
            }
            else
            {
                throw new ArgumentNullException("Title is empty");
            }
        }

        private int SetIdAward()
        {
            if (GetAwards().ToList().Count == 0)
            {
                return 1;
            }
            else
            {
                return GetAwards().ToList().Last().IdAward + 1;
            }
        }
    }
}
