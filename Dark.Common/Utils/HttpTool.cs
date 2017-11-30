﻿using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dark.Common.Utils
{
    //通用的http请求库
    public class HttpTools
    {
        /// <summary>
        /// 简单的通过网页请求,来获取页面的数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> GetAsyncByUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var httpResponseMessage = await client.GetAsync(url);
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// 下载一个流
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<Stream> DownloadAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStreamAsync(url);
            }
        }
    }
}
