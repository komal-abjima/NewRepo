using Five9;

namespace Five9_test.Service.Helper
{
    public class SaveFile
    {
            public async static Task<string> SaveFileToLocation(byte[] apiresponse)
            {
                try
                {
                    var filename = $"{Guid.NewGuid()}" + ".mp3";
                    var folderPath = Constants.FilePath;

                    var filepath = Path.Combine(folderPath, filename);

                    await File.WriteAllBytesAsync(filepath, apiresponse);

                    return filepath;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }

