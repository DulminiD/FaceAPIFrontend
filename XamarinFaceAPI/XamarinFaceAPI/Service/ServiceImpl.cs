using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFaceAPI.Model;

namespace XamarinFaceAPI.Service
{
    class ServiceImpl : IService
    {
        #region Declarations
        HttpClient _client;
        object _faceAttributes;
        readonly string SENDURL = "https://faceapidul.herokuapp.com/urlRoute/url";
        readonly string GETURL = "https://faceapidul.herokuapp.com/urlRoute/getData";
        #endregion

        #region Constructor
        public ServiceImpl()
        {
            _client = new HttpClient();
        }
        #endregion

        #region Get Details
        public async Task GetAttributes(string urllink)
        {

            URLModel uRLModel = new URLModel();
            uRLModel.url = urllink;

            var url = JsonConvert.SerializeObject(uRLModel);

            var content = new StringContent(url, Encoding.UTF8, "application/json");

            var response = _client.PostAsync(SENDURL, content).Result;
                      
            var data = _client.GetStringAsync(GETURL).Result;
           
            _faceAttributes = JsonConvert.DeserializeObject(data);

        }
        #endregion

        #region Send Details
        public object SendData()
        {
            return _faceAttributes;
        }
        #endregion
    }
}
