using System;

public class Mission : IMission
{
    public Mission(string codeName, string missionState)
    {
        this.CodeName = codeName;
        ParseMissionState(missionState);
    }

    public string CodeName { get; }
    public MissionState State { get; private set; }

    private void ParseMissionState(string missionState)
    {
        bool validState = Enum.TryParse(typeof(MissionState), missionState, out object outState);

        if (!validState)
        {
            throw new ArgumentException("Invalid state!");
        }

        this.State = (MissionState)outState;
    }

    public void Complete()
    {
        if (this.State == MissionState.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }

        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}

