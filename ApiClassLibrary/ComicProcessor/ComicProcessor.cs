using ApiClassLibrary.ApiAccess;
using ApiClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClassLibrary.ComicProcessor
{
    public static class ComicProcessor
    {
        /// <summary>
        /// /This is the business Logic of the client.
        /// </summary>
        /// <param name="comicNumber"></param>
        /// <returns></returns>
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {

            string url = "";

            if (comicNumber > 1)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json ";
            }

            else
            {
                url = $"https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }



    }
}
