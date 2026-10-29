namespace MCPForUnity.Runtime.Recording
{
    /// <summary>
    /// Opt-in playback contract for project state machines and tween engines.
    /// Implement on a MonoBehaviour; all calls run on Unity's main thread.
    /// Advance is driven by the recorder: do not also auto-update while recording.
    /// </summary>
    public interface IRecordingPlaybackSource
    {
        string RecordingId { get; }
        string[] States { get; }
        double FrameRate { get; }
        double DurationSeconds { get; }
        bool CanSeek { get; }
        object CaptureState();
        void Prepare(string state);
        void Seek(double timeSeconds);
        void Advance(double deltaSeconds);
        /// <summary>Release recorder ownership; null means keep the final visual state.</summary>
        void RestoreState(object snapshot);
    }
}
