using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using MediatR;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        
        public string AccessToken
        {
            get
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authHeaderValues))
                {
                    string accessToken = authHeaderValues.ToString();
                    return accessToken.StartsWith("Bearer ") ? accessToken.Substring("Bearer ".Length).Trim() : accessToken;
                }

                return "";
            }
        }
    }
}

/*TOKEN BİLGİSİ İLE YAPILABİLECEKLER
Kullanıcı Kimliği Kontrolü:

Token içinde kullanıcı kimliği (user ID) bilgisi yer alıyorsa, bu bilgiyi alarak işlem yapan kullanıcının kim olduğunu öğrenebilirsiniz.
Kullanıcı kimliğine göre belirli işlemleri sınırlayabilir veya izin verebilirsiniz.
Yetkilendirme:

Token içindeki roller veya yetkilendirme bilgilerini kontrol ederek kullanıcının belirli işlemleri yapmaya yetkili olup olmadığını belirleyebilirsiniz.
Örneğin, sadece belirli bir role sahip kullanıcıların bu CreatePrompt işlemini yapmasına izin verebilirsiniz.
İzleme ve Kayıt Tutma:

Token içindeki bilgileri kullanarak işlem yapan kullanıcıların aktivitelerini izleyebilir ve kayıt altına alabilirsiniz.
Bu, güvenlik ve hata ayıklama açısından önemli olabilir.
Token Geçerlilik Kontrolü:

Token'ın geçerliliğini kontrol ederek işlem yapmadan önce token'ın süresinin dolup dolmadığını veya geçerli olup olmadığını doğrulayabilirsiniz.*/
