// MIT License
// 
// Copyright (c) 2019 WhetstoneTechnologies
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa.Audio
{

    /// <summary>
    /// Indicates state of the audio player interface
    /// </summary>
    /// <remarks>
    /// For more information see <a href="https://developer.amazon.com/docs/alexa-voice-service/audioplayer.html">Audio Player Interface</a>.
    /// </remarks>
    [Serializable]
    public enum AudioPlayerActivityEnum
    {
        /// <summary>
        /// AudioPlayer is only in an idle state when a product is initially powered on or rebooted and prior to acting on a Play directive.
        /// </summary>
        [EnumMember(Value = "IDLE")]
        Idle =0,

        /// <summary>
        /// When your client initiates playback of an audio stream, AudioPlayer must transition from an idle state to playing.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If you receive a directive instructing your client to perform an action, such as pausing or stopping the audio stream, if the client 
        /// has trouble buffering the stream, or if playback fails, AudioPlayer must transition to the appropriate state when the action is performed 
        /// (and send an event to AVS). Otherwise, AudioPlayer must remain in the playing state until the current stream has finished.
        /// </para>
        /// <para>
        /// Additionally, AudioPlayer must remain in the playing state when:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>Reporting playback progress to AVS</description>        
        /// </item>
        /// <item>
        /// <description>Sending stream metadata to AVS</description>        
        /// </item>
        /// </list>
        /// </remarks>
        [EnumMember(Value = "PLAYING")]
        Playing =1,


        /// <summary>
        /// Default value of the request when starting a new session.
        /// </summary>
        /// <remarks>
        /// <para>There are four instances when AudioPlayer must transition to the stopped state. While in the playing state, AudioPlayer must transition to stopped when:</para>
        /// <list type="bullet">
        /// <item><description>An issue with the stream is encountered and playback fails</description></item>
        /// <item><description>Sending stream metadata to AVS</description></item>
        /// <item><description>A ClearQueue directive with a clearBehavior of CLEAR_ALL is received</description></item>
        /// <item><description>A Play directive with a playBehavior of REPLACE_ALL is received</description></item>
        /// </list>
        /// <para>While in the paused or buffer_underrun states, AudioPlayer must transition to stopped when a ClearQueue directive to CLEAR_ALL is received.</para>
        /// <para>AudioPlayer must transition from stopped to playing whenever your client receives a Play directive, starts playing an audio stream, and sends a PlaybackStarted event to the AVS.</para>
        /// </remarks>
        [EnumMember(Value = "STOPPED")]
        Stopped =2,

        /// <summary>
        /// AudioPlayer must transition to the paused state when audio on the Content channel is paused to accommodate a higher priority input/output (such as user or Alexa speech). 
        /// </summary>
        /// <remarks> Playback must resume when the prioritized activity completes. For more information on prioritizing audio input/outputs. See <a href="https://developer.amazon.com/docs/alexa-voice-service/interaction-model.html">Interaction Model</a></remarks>
        [EnumMember(Value = "PAUSED")]
        Paused =3,

        /// <summary>
        /// AudioPlayer must transition to the buffer_underrun state when the client is being fed data slower than it is being read. 
        /// AudioPlayer must remain in this state until the buffer is full enough to resume playback, 
        /// at which point it must return to the playing state.
        /// </summary>
        [EnumMember(Value = "BUFFER_UNDERRUN")]
        BufferUnderrun =4,


        /// <summary>
        /// When a stream is finished playing, AudioPlayer must transition to the finished state. This is true for every stream in your playback queue. Even if there are streams queued to play, your client is required to send a PlaybackFinished event to AVS, 
        /// and subsequently, transition from the playing state to finished when each stream is finished playing.
        /// </summary>
        /// <remarks>
        /// <para>AudioPlayer must transition from finished to playing when:</para>
        /// <list type="bullet">
        /// <item><description>The client receives a Play directive</description></item>
        /// <item><description>The next stream in the playback queue starts playing (following a PlaybackStarted event).</description></item>
        /// </list>
        /// </remarks>
        [EnumMember(Value = "FINISHED")]
        Finished =5


    }

    /// <summary>
    /// Contains the state of audio player on the user's device.
    /// </summary>
    /// <remarks>
    /// For more information about the audio player, see: https://developer.amazon.com/docs/alexa-voice-service/audioplayer.html
    /// </remarks>
    public class AudioPlayerRequestAttributes
    {


        /// <summary>
        /// Indicates the client status of the audio player. Defaults to Stopped on launch.
        /// </summary>
        [JsonConverter(typeof(JsonEnumConverter<AudioPlayerActivityEnum>))]
        [JsonProperty("playerActivity", NullValueHandling = NullValueHandling.Ignore)]
        public AudioPlayerActivityEnum PlayerActivity { get; set; }

    }
}
