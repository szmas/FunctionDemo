using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TokenDemo
{
    class Program
    {

        #region Base64
        static string Base64EnCode(string enstr)
        {
            var bytes = Encoding.Default.GetBytes(enstr);

            var bae64 = Convert.ToBase64String(bytes);

            return bae64;
        }

        static string Base64DeCode(string deStr)
        {
            var bytes = Convert.FromBase64String(deStr);

            var str = Encoding.Default.GetString(bytes);

            return str;
        }

        #endregion


        #region HMAC-SHA256 加密

        /// <summary>
        /// HMAC-SHA256 加密
        /// </summary>
        /// <param name="input"> 要加密的字符串 </param>
        /// <param name="key"> 密钥 </param>
        /// <param name="encoding"> 字符编码 </param>
        /// <returns></returns>
        public static string HMACSHA256Encrypt(string input, string key)
        {
            return HashEncrypt(new HMACSHA256(Encoding.Default.GetBytes(key)), input, Encoding.Default);
        }

        static string HashEncrypt(HashAlgorithm hashAlgorithm, string input, Encoding encoding)
        {
            var data = hashAlgorithm.ComputeHash(encoding.GetBytes(input));
            return Convert.ToBase64String(data);
        }

        #endregion

        static void Main(string[] args)
        {

            #region 字符串Base64转化




            #endregion

            ///  JWT+HA256验证



            /*

            JWT=header.payload.signature


            实施 Token 验证的方法挺多的，还有一些标准方法，比如 JWT，读作：jot ，表示：JSON Web Tokens 。JWT 标准的 Token 有三个部分：

            header
            payload
            signature
            中间用点分隔开，并且都会使用 Base64 编码，所以真正的 Token 看起来像这样：




            

            初次登录：用户初次登录，输入用户名密码
            密码验证：服务器从数据库取出用户名和密码进行验证
            生成JWT：服务器端验证通过，根据从数据库返回的信息，以及预设规则，生成JWT
            返还JWT：服务器的HTTP RESPONSE中将JWT返还
            带JWT的请求：以后客户端发起请求，HTTP REQUEST HEADER中的Authorizatio字段都要有值，为JWT

            
             
             */

            /*
             
             header(头部) 部分主要是两部分内容，一个是 Token 的类型，另一个是使用的算法，比如下面类型就是 JWT，使用的算法是 HS256。
             
             */

            string Header = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";


            /*
             
             Payload(载荷) 里面是 Token 的具体内容，这些内容里面有一些是标准字段，你也可以添加其它需要的内容。下面是标准字段：

            iss：Issuer，发行者
            sub：Subject，主题
            aud：Audience，观众
            exp：Expiration time，过期时间
            nbf：Not before
            iat：Issued at，发行时间
            jti：JWT ID
             
             */

            string Payload = "{\"iss\": \"ninghao.net\",\"exp\": \"1438955445\",\"name\": \"wanghao\",\"admin\":true}";
            //Payload = "{\"sub\":\"1234567890\",\"name\":\"John Doe\",\"admin\":true}";

            /*
             
            Signature(签名)

            JWT 的最后一部分是 Signature ，这部分内容有三个部分，先是用 Base64 编码的 header.payload ，再用加密算法加密一下，加密的时候要放进去一个 Secret ，这个相当于是一个密码，这个密码秘密地存储在服务端。

             注意：secret是保存在服务器端的，jwt的签发生成也是在服务器端的，secret就是用来进行jwt的签发和jwt的验证，
             所以，它就是你服务端的私钥，在任何场景都不应该流露出去。一旦客户端得知这个secret, 那就意味着客户端是可以自我签发jwt了。 

            
            Signature= HMACSHA256Encrypt(Base64EnCode(header)+"."+ Base64EnCode(payload),"secret");
             
             */


            string secret = "secret";//加密密钥

            var encodedString = Base64EnCode(Header) + "." + Base64EnCode(Payload);
            var signature = HMACSHA256Encrypt(encodedString, secret);


            var jwt = Base64EnCode(Header) + "." + Base64EnCode(Payload) + "." + signature;

            //在我们的请求URL中会带上这串JWT字符串：，
            //这个Token信息可能在COOKIE中，也可能在HTTP的Authorization头中；
            Console.WriteLine("服务端生成的JWT Token：" + jwt);


            //签名验证

            /*
             
             先说签名验证。当接收方接收到一个JWT的时候，首先要对这个JWT的完整性进行验证，这个就是签名认证。它验证的方法其实很简单，
             只要把header做base64url解码，就能知道JWT用的什么算法做的签名，然后用这个算法，再次用同样的逻辑对header和payload做一次签名，
             并比较这个签名是否与JWT本身包含的第三个部分的串是否完全相同，只要不同，就可以认为这个JWT是一个被篡改过的串，自然就属于验证失败了。
             接收方生成签名的时候必须使用跟JWT发送方相同的密钥，意味着要做好密钥的安全传递或共享。
             
             */


            var verified = HMACSHA256Encrypt(Base64EnCode(Header) + "." + Base64EnCode(Payload), secret) == signature;

            Console.WriteLine("Token签名验证：" + verified);


            //在线验证  https://jwt.io/


            /*
             
             
             优点
                    JWT是无法伪造，无法篡改的
                    因为json的通用性，所以JWT是可以进行跨语言支持的，像JAVA,JavaScript,NodeJS,PHP等很多语言都可以使用。
                    因为有了payload部分，所以JWT可以在自身存储一些其他业务逻辑所必要的非敏感信息。
                    便于传输，jwt的构成非常简单，字节占用很小，所以它是非常便于传输的。
                    它不需要在服务端保存会话信息, 所以它易于应用的扩展
                    安全相关

                    不应该在jwt的payload部分存放敏感信息，因为该部分是客户端可解密的部分。
                    保护好secret私钥，该私钥非常重要。
                    如果可以，请使用https协议
             
             
             
             */
        }
    }
}
