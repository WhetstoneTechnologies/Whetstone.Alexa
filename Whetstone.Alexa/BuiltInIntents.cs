// Copyright (c) 2018 Whetstone Technologies
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
namespace Whetstone.Alexa
{

    /// <summary>
    /// Encloses the built-in intents supported by Alexa.
    /// </summary>
    public class BuiltInIntents
    {


        /// <summary>
        /// Either of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>Let the user cancel a transaction or task (but remain in the skill)</description>        
        /// </item>
        /// <item>
        /// <description>Let the user completely exit the skill</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the AudioPlayer interface, users can invoke this intent without using your 
        /// invocation name if your skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this 
        /// case even if AMAZON.CancelIntent is not in your intent schema.</para>
        /// <para>
        /// Common utterances are:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>forget it</description>        
        /// </item>
        /// <item>
        /// <description>never mind</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string CancelIntent = "AMAZON.CancelIntent";


        /// <summary>
        /// <para>Provides a fallback for user utterances that do not match any of your skill's intents. 
        /// Your AMAZON.FallbackIntent handler can give the user more details on what your skill does and how they can interact with it.</para>
        /// <para>
        /// (Available for English locales only)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Utterances vary. This intent uses an out-of-domain model generated based on your interaction model. See Provide a Fallback for Unmatched Utterances.
        /// https://developer.amazon.com/docs/custom-skills/standard-built-in-intents.html#fallback
        /// </remarks>
        public static readonly string FallbackIntent = "AMAZON.FallbackIntent";


        /// <summary>
        /// Provide help about how to use the skill. See What Alexa Says (https://developer.amazon.com/designing-for-voice/what-alexa-says/) 
        /// for guidelines about contextualized help.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Common utterances are:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>help</description>        
        /// </item>
        /// <item>
        /// <description>help me</description>
        /// </item>
        /// <item>
        /// <description>can you help me</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string HelpIntent = "AMAZON.HelpIntent";



        /// <summary>
        /// Lets the user request that the skill turn off a loop or repeat mode, usually for audio skills that stream a playlist of tracks.
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the AudioPlayer interface, users can invoke this intent without using your invocation name if your skill is currently playing audio 
        /// or was the most recent skill to play audio. 
        /// The intent is sent to your skill in this case even if AMAZON.LoopOffIntent is not in your intent schema.</para>
        /// <para>
        /// The utterance is:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>loop off</description>        
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string LoopOffIntent = "AMAZON.LoopOffIntent";



        /// <summary>
        /// Lets the user request that the skill turn on a loop or repeat mode, usually for audio skills that stream a playlist of tracks.
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the AudioPlayer interface, users can invoke this intent without using your invocation name if your skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this case even if AMAZON.LoopOnIntent is not in your intent schema.</para>
        /// <list type="bullet">
        /// <item>
        /// <description>loop</description>        
        /// </item>
        /// <item>
        /// <description>loop on</description>        
        /// </item>
        /// <item>
        /// <description>keep playing this</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string LoopOnIntent = "AMAZON.LoopOnIntent";

        /// <summary>
        /// Let the user navigate to the next item in a list.
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the AudioPlayer interface, users can invoke this intent without using your invocation name if your 
        /// skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this case even if AMAZON.NextIntent 
        /// is not in your intent schema.</para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>next</description>        
        /// </item>
        /// <item>
        /// <description>skip</description>        
        /// </item>
        /// <item>
        /// <description>skip forward</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string NextIntent = "AMAZON.NextIntent";




        /// <summary>
        /// Let the user provide a negative response to a yes/no question for confirmation.
        /// </summary>
        /// <remarks>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>no</description>        
        /// </item>
        /// <item>
        /// <description>no thanks</description>        
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string NoIntent = "AMAZON.NoIntent";


        /// <summary>
        /// Let the user pause an action in progress, such as pausing a game or pausing an audio track that is playing.
        /// </summary>
        /// <remarks>
        /// <para>You <i>must</i> implement this intent if your skill streams audio using the AudioPlayer interface. Users can invoke this intent without using your invocation name if your skill is currently playing audio or was the most recent skill to play audio.</para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>pause</description>        
        /// </item>
        /// <item>
        /// <description>pause that</description>        
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string PauseIntent = "AMAZON.PauseIntent";




        /// <summary>
        /// Let the user request to repeat the last action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// For skills that stream audio using the <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html" target="_blank">AudioPlayer interface</a>, users can 
        /// <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#intents" target="_blank">invoke this intent without using your invocation name</a> if your 
        /// skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this case even if 
        /// AMAZON.RepeatIntent is not in your intent schema.
        /// </para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>repeat</description>        
        /// </item>
        /// <item>
        /// <description>repeat that</description>        
        /// </item>
        /// <item>
        /// <description>say that again</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string RepeatIntent = "AMAZON.RepeatIntent";


        /// <summary>
        /// Let the user resume or continue an action.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You <i>must</i> implement this intent if your skill streams audio using the <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html" target="_blank">AudioPlayer interface</a>. 
        /// Users can <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#intents" target="_blank">invoke this intent without using your invocation name</a> if your skill is currently playing audio or was the most recent skill to play audio.
        /// </para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>resume</description>        
        /// </item>
        /// <item>
        /// <description>continue</description>        
        /// </item>
        /// <item>
        /// <description>keep going</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string ResumeIntent = "AMAZON.ResumeIntent";

        /// <summary>
        /// Lets the user request that the skill turn <i>off</i> a shuffle mode, usually for audio skills that stream a playlist of tracks.
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html" target="_blank">AudioPlayer interface</a>, 
        /// users can <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#intents" target="_blank">invoke this intent without using your invocation name</a> 
        /// if your skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this case even if AMAZON.ShuffleOffIntent is not in your intent schema.</para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>stop shuffling</description>        
        /// </item>
        /// <item>
        /// <description>shuffle off</description>        
        /// </item>
        /// <item>
        /// <description>turn off shuffle</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string ShuffleOffIntent = "AMAZON.ShuffleOffIntent";



        /// <summary>
        /// Lets the user request that the skill turn <i>on</i> a shuffle mode, usually for audio skills that stream a playlist of tracks.
        /// </summary>
        /// <remarks>
        /// <para>
        /// For skills that stream audio using the <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html" target="_blank">AudioPlayer interface</a>, 
        /// users can <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#intents" target="_blank">invoke this intent without using your invocation name</a>  
        /// if your skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this case even 
        /// if AMAZON.ShuffleOnIntent is not in your intent schema.
        /// </para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>shuffle</description>        
        /// </item>
        /// <item>
        /// <description>shuffle on</description>        
        /// </item>
        /// <item>
        /// <description>shuffle the music</description>
        /// </item>
        /// <item>
        /// <description>shuffle mode</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string ShuffleOnIntent = "AMAZON.ShuffleOnIntent";

        /// <summary>
        /// Let the user request to restart an action, such as restarting a game, transaction, or audio track.
        /// </summary>
        /// <remarks>
        /// <para>For skills that stream audio using the <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html" target="_blank">AudioPlayer interface</a>, 
        /// users can <a href="https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html#intents" target="_blank">invoke this intent without using your invocation name</a> 
        /// if your skill is currently playing audio or was the most recent skill to play audio. The intent is sent to your skill in this 
        /// case even if AMAZON.StartOverIntent is not in your intent schema.</para>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>start over</description>        
        /// </item>
        /// <item>
        /// <description>restart</description>        
        /// </item>
        /// <item>
        /// <description>start again</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string StartOverIntent = "AMAZON.StartOverIntent";

        /// <summary>
        /// Either of the following:
        /// <list type="bullet">
        /// <item><description>Let the user stop an action(but remain in the skill)</description></item>
        /// <item><description>Let the user completely exit the skill</description></item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>stop</description>        
        /// </item>
        /// <item>
        /// <description>off</description>        
        /// </item>
        /// <item>
        /// <description>shut up</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string StopIntent = "AMAZON.StopIntent";



        /// <summary>
        /// Let the user provide a positive response to a yes/no question for confirmation.
        /// </summary>
        /// <remarks>
        /// <para>Common utterances are:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>yes</description>        
        /// </item>
        /// <item>
        /// <description>yes please</description>        
        /// </item>
        /// <item>
        /// <description>sure</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly string YesIntent = "AMAZON.YesIntent";



        /// <summary>
        /// For use with devices with screens. Scrolls the display up.
        /// </summary>
        /// <remarks>
        /// Scroll up in the display device, like Echo Show.
        /// </remarks>
        public static readonly string ScrollUpIntent =  "AMAZON.ScrollUpIntent";



        /// <summary>
        /// For use with devices with screens. Scrolls the display down.
        /// </summary>
        /// <remarks>
        /// Scroll down in the display device, like Echo Show.
        /// </remarks>
        public static readonly string ScrollDownIntent = "AMAZON.ScrollDownIntent";


        /// <summary>
        /// For use with devices with screens. Scrolls the display left.
        /// </summary>
        /// <remarks>
        /// Scroll left in the display device, like Echo Show.
        /// </remarks>
        public static readonly string ScrollLeftIntent = "AMAZON.ScrollLeftIntent";


        /// <summary>
        /// For use with devices with screens. Scrolls the display right.
        /// </summary>
        /// <remarks>
        /// Scroll right in the display device, like Echo Show.
        /// </remarks>
        public static readonly string ScrollRightIntent = "AMAZON.ScrollRightIntent";



        /// <summary>
        /// For use with display devices. Similar to the <see cref="Whetstone.Alexa.BuiltInIntents.ScrollUpIntent">AMAZON.ScrollUpIntent</see>.
        /// </summary>
        /// <remarks>
        /// Page up in a display device, like Echo Show.
        /// </remarks>
        public static readonly string PageUpIntent = "AMAZON.PageUpIntent";

        /// <summary>
        /// For use with display devices. Similar to the <see cref="Whetstone.Alexa.BuiltInIntents.ScrollDownIntent">AMAZON.ScrollDownIntent</see>.
        /// </summary>
        /// <remarks>
        /// Page down in a display device, like Echo Show.
        /// </remarks>
        public static readonly string PageDownIntent = "AMAZON.PageDownIntent";


        /// <summary>
        /// For use with display devices. Similar to the <see cref="Whetstone.Alexa.BuiltInIntents.ScrollDownIntent">AMAZON.ScrollDownIntent</see> and
        /// <see cref="Whetstone.Alexa.BuiltInIntents.ScrollRightIntent">AMAZON.ScrollRightIntent</see>.
        /// </summary>
        /// <remarks>
        /// Page down or move right in a display device, like Echo Show.
        /// </remarks>
        public static readonly string MoreIntent = "AMAZON.MoreIntent";


        /// <summary>
        /// Navigate user to the device home screen. The skill session will end. 
        /// </summary>
        /// <remarks>For use with display devices, like Echo Show.</remarks>
        public static readonly string NavigateHomeIntent = "AMAZON.NavigateHomeIntent";

        /// <summary>
        /// Navigate user to the Device Settings screen, and the skill session will continue.
        /// </summary>
        /// <remarks>For use with display devices, like Echo Show.</remarks>
        public static readonly string NavigateSettingsIntent = "AMAZON.NavigateSettingsIntent";

    }
}
