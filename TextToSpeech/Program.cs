using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
using System.Speech.AudioFormat;

namespace TextToSpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer mySpeaker = new SpeechSynthesizer();
            VoiceGender myVoice = VoiceGender.Male;
            VoiceAge myAge = VoiceAge.Senior;

            
            mySpeaker.Rate = 0;
            mySpeaker.SetOutputToDefaultAudioDevice();
            mySpeaker.SelectVoiceByHints(myVoice, myAge);
            mySpeaker.SpeakAsync("Barnabas Nomo Mawukley");

            
            

            /*
             * Read from text file
            string[] jerome = File.ReadAllLines("Results.txt");
            foreach (var myFile in jerome)
            {
                mySpeaker.SpeakAsync(myFile);
            }
             * 
            */
            Console.WriteLine("Installed Voices: ");
            foreach (InstalledVoice voice in mySpeaker.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                // Remember To Check Audio Format Info 

                string AudioFormats = "";
                foreach (SpeechAudioFormatInfo format in info.SupportedAudioFormats)
                {
                    AudioFormats += String.Format("{0}\n", format.EncodingFormat.ToString());
                }


                Console.WriteLine(" Name\t" + info.Name);
                Console.WriteLine(" Culture\t" + info.Culture);
                Console.WriteLine(" Age\t" + info.Age);
                Console.WriteLine(" Gender\t" + info.Gender);
                Console.WriteLine(" Description\t" + info.Description);
                Console.WriteLine(" ID\t" + info.Id);
                Console.WriteLine(" Enabled\t" + voice.Enabled);


                if (info.SupportedAudioFormats.Count != 0)
                {
                    Console.WriteLine(" Audio Formats: " + AudioFormats);
                }
                else
                {
                    Console.WriteLine(" No supported audio formats found");
                }
                string AdditionalInfo = "";
                foreach (string key in info.AdditionalInfo.Keys)
                {
                    AdditionalInfo += String.Format(" {0}: {1}\n", key, info.AdditionalInfo[key]);
                }
                mySpeaker.SpeakAsync(AdditionalInfo);
                Console.WriteLine(AdditionalInfo);
            }



            
            Console.ReadLine();
        }
    }
}
