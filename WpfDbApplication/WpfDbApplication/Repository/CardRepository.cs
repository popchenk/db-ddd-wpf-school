using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DTOs;

namespace WpfDbApplication.Repository
{
    public class CardRepository : BaseRepository<CardDto>, ICardRepository
    {
        public CardRepository(IUnitOfWork uow) : base(uow) { }

        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(CardDto entity, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@CardNum", entity.cardNum);
            cmd.Parameters.AddWithValue("@Cvv", entity.cvv);
            cmd.Parameters.AddWithValue("@ExpDate", entity.expDate);
        }
        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(CardDto entity, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@CardNum", entity.cardNum);
            cmd.Parameters.AddWithValue("@Cvv", entity.cvv);
            cmd.Parameters.AddWithValue("@ExpDate", entity.expDate);
        }

        /// <summary>
        /// Passes the parameters to command for Delete Statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteCommandParameters(int id, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters to command for populate by key statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void GetByIdCommandParameters(int id, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<CardDto> Map(SQLiteDataReader reader)
        {
            CardDto card = new CardDto();
            if (reader.HasRows)
            {
                await Task.Run(() =>
                {
                    while (reader.Read())
                    {
                        card.Id = Convert.ToInt32(reader["Id"].ToString());
                        card.cardNum = reader["CardNum"].ToString();
                        card.cvv = Convert.ToInt32(reader["Cvv"].ToString());
                        card.expDate = reader["ExpDate"].ToString();
                    }
                });
            }
            return card;
        }

        /// <summary>
        /// Maps data for populate all statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<List<CardDto>> Maps(SQLiteDataReader reader)
        {
            List<CardDto> cards = new List<CardDto>();
            if (reader.HasRows)
            {
                await Task.Run(() =>
                {
                    while (reader.Read())
                    {
                        CardDto card = new CardDto();
                        card.Id = Convert.ToInt32(reader["Id"].ToString());
                        card.cardNum = reader["CardNum"].ToString();
                        card.cvv = Convert.ToInt32(reader["Cvv"].ToString());
                        card.expDate = reader["ExpDate"].ToString();
                        cards.Add(card);
                    }
                });
            }
            return cards;
        }
    }
}
