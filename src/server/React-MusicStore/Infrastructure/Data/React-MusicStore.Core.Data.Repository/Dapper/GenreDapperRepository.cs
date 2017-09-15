using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly;

namespace ReactMusicStore.Core.Data.Repository.Dapper
{
    public class GenreDapperRepository : Common.Repository, IGenreReadOnlyRepository
    {
        public Genre Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var genres = cn.Query<Genre>("SELECT * FROM Genre WHERE GenreId = @GenreId",
                    new {GenreId = id}).FirstOrDefault();
                return genres;
            }
        }

        public Genre GetWithAlbums(string genreName)
        {
            using (var cn = MusicStoreConnection)
            {
                var dr = cn.ExecuteReader(
                    "SELECT * " +
                    "  FROM Genre G" +
                    "  JOIN Album A ON A.GenreId = G.GenreId" +
                    " WHERE G.Name = @Name", new {Name = genreName});

                Genre genre = null;
                while (dr.Read())
                {
                    if (genre == null)
                    {
                        genre = new Genre
                        {
                            Id = Convert.ToInt32(dr["GenreId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString()
                        };
                    }

                    genre.Albums.Add(new Album
                    {
                        Id = Convert.ToInt32(dr["AlbumId"]),
                        Title = dr["Title"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        AlbumArtUrl = dr["AlbumArtUrl"].ToString(),
                        GenreId = Convert.ToInt32(dr["GenreId"]),
                        Genre = genre
                    });
                }
                return genre;
            }
        }

        public IEnumerable<Genre> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var genre = cn.Query<Genre>("SELECT * FROM Genre");
                return genre;
            }
        }

        public IEnumerable<Genre> Find(Expression<Func<Genre, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var genres = cn.GetList<Genre>(predicate);
                return genres;
            }
        }
    }
}
