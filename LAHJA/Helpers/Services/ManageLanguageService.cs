using Microsoft.JSInterop;
using Shared.Constants;
using System.ComponentModel;
namespace LAHJA.Helpers.Services
{

    public class LanguageService
    {
        public event Action<string> OnLanguageChanged;
        private string _currentLanguage = "ar";

        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    NotifyLanguageChanged(_currentLanguage);
                }
            }
        }

        private void NotifyLanguageChanged(string langCode)
        {
            OnLanguageChanged?.Invoke(langCode);
        }
    }



    public enum LanguagesCode{
        [Description("ar")]
        AR,

        [Description("en")]
        EN
    }
    public interface IManageLanguageService
    {
        Task<string> GetLanguageAsync();
        //Task SetLanguageAsync(string languageCode);
        Task<bool> CheckIsLanguage(LanguagesCode code);
        Task SetLanguageAsync(LanguagesCode code);
    }
    public class ManageLanguageService: IManageLanguageService
    {
        private readonly IJSRuntime _jsRuntime;
        public ManageLanguageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public  async Task<string> GetLanguageAsync()
        {
            

            try
            {
                return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.LANGUAGE_STORAGE) ?? LanguagesCode.AR.ToString().ToLower();
            }
            catch (Exception ex)
            {
                return LanguagesCode.AR.ToString().ToLower();
            }
        }
        public  async Task<bool> CheckIsLanguage(LanguagesCode code)
        {
         
            var lang = await GetLanguageAsync();
            if (!string.IsNullOrEmpty(lang))
            {
                return (lang.ToLower() == code.ToString().ToLower());
            }
            return false;   
        }
        public  async Task SetLanguageAsync(LanguagesCode code)
        {
            if (code!=null)
            {
                try
                {
                    
                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LANGUAGE_STORAGE,(code.ToString().ToLower()) );
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
