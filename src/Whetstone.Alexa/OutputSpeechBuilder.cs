using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{
    public static class OutputSpeechBuilder
    {


        public static OutputSpeechAttributes GetPlainTextSpeech(string text)
        {
            OutputSpeechAttributes outputSpeech = new OutputSpeechAttributes(OutputSpeechType.PlainText, text);
            return outputSpeech;
        }


        public static OutputSpeechAttributes GetSsmlSpeech(string ssmlText)
        {
            OutputSpeechAttributes outputSpeech = new OutputSpeechAttributes(OutputSpeechType.Ssml, ssmlText);
            return outputSpeech;
        }


    }
}
