using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Audio.AmazonSoundLibrary
{

    /// <summary>
    /// This is the list of all ambient sound effects in the Amazon Sound Library.
    /// </summary>
    /// <remarks>
    /// To play the sample files, go to <a href="https://developer.amazon.com/docs/custom-skills/ambience-sounds.html">Ambience Sounds</a>
    /// </remarks>
    public static class Ambience
    {
        public static readonly string CROWD_BAR_01 = "<audio src='soundbank://soundlibrary/ambience/amzn_sfx_crowd_bar_01'/>";

        public static readonly string CROWD_BAR_ROWDY_01 = "<audio src='soundbank://soundlibrary/ambience/amzn_sfx_crowd_bar_rowdy_01'/>";
    }
}
