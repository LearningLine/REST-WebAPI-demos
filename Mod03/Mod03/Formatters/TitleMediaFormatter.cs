using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using Mod03.Models;

namespace Mod03.Formatters
{
    public class TitleMediaFormatter: BufferedMediaTypeFormatter
    {
        public TitleMediaFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd-movie-title"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
         return   typeof (Book).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content, CancellationToken cancellationToken)
        {
            var book = value as Book;

            using (var sw = new StreamWriter(writeStream))
            {
                sw.WriteLine(book.Title);
            }

        }
    }
}