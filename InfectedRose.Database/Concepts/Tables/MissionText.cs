namespace InfectedRose.Database.Concepts.Tables
{
    public class MissionTextTable

    {
        public MissionTextTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string story_icon
        {
            get => (string) Column["story_icon"].Value;

            set => Column["story_icon"].Value = value;
        }

        public string missionIcon
        {
            get => (string) Column["missionIcon"].Value;

            set => Column["missionIcon"].Value = value;
        }

        public string offerNPCIcon
        {
            get => (string) Column["offerNPCIcon"].Value;

            set => Column["offerNPCIcon"].Value = value;
        }

        public int IconID
        {
            get => (int) Column["IconID"].Value;

            set => Column["IconID"].Value = value;
        }

        public string state_1_anim
        {
            get => (string) Column["state_1_anim"].Value;

            set => Column["state_1_anim"].Value = value;
        }

        public string state_2_anim
        {
            get => (string) Column["state_2_anim"].Value;

            set => Column["state_2_anim"].Value = value;
        }

        public string state_3_anim
        {
            get => (string) Column["state_3_anim"].Value;

            set => Column["state_3_anim"].Value = value;
        }

        public string state_4_anim
        {
            get => (string) Column["state_4_anim"].Value;

            set => Column["state_4_anim"].Value = value;
        }

        public string state_3_turnin_anim
        {
            get => (string) Column["state_3_turnin_anim"].Value;

            set => Column["state_3_turnin_anim"].Value = value;
        }

        public string state_4_turnin_anim
        {
            get => (string) Column["state_4_turnin_anim"].Value;

            set => Column["state_4_turnin_anim"].Value = value;
        }

        public string onclick_anim
        {
            get => (string) Column["onclick_anim"].Value;

            set => Column["onclick_anim"].Value = value;
        }

        public string CinematicAccepted
        {
            get => (string) Column["CinematicAccepted"].Value;

            set => Column["CinematicAccepted"].Value = value;
        }

        public float CinematicAcceptedLeadin
        {
            get => (float) Column["CinematicAcceptedLeadin"].Value;

            set => Column["CinematicAcceptedLeadin"].Value = value;
        }

        public string CinematicCompleted
        {
            get => (string) Column["CinematicCompleted"].Value;

            set => Column["CinematicCompleted"].Value = value;
        }

        public float CinematicCompletedLeadin
        {
            get => (float) Column["CinematicCompletedLeadin"].Value;

            set => Column["CinematicCompletedLeadin"].Value = value;
        }

        public string CinematicRepeatable
        {
            get => (string) Column["CinematicRepeatable"].Value;

            set => Column["CinematicRepeatable"].Value = value;
        }

        public float CinematicRepeatableLeadin
        {
            get => (float) Column["CinematicRepeatableLeadin"].Value;

            set => Column["CinematicRepeatableLeadin"].Value = value;
        }

        public string CinematicRepeatableCompleted
        {
            get => (string) Column["CinematicRepeatableCompleted"].Value;

            set => Column["CinematicRepeatableCompleted"].Value = value;
        }

        public float CinematicRepeatableCompletedLeadin
        {
            get => (float) Column["CinematicRepeatableCompletedLeadin"].Value;

            set => Column["CinematicRepeatableCompletedLeadin"].Value = value;
        }

        public string AudioEventGUID_Interact
        {
            get => (string) Column["AudioEventGUID_Interact"].Value;

            set => Column["AudioEventGUID_Interact"].Value = value;
        }

        public string AudioEventGUID_OfferAccept
        {
            get => (string) Column["AudioEventGUID_OfferAccept"].Value;

            set => Column["AudioEventGUID_OfferAccept"].Value = value;
        }

        public string AudioEventGUID_OfferDeny
        {
            get => (string) Column["AudioEventGUID_OfferDeny"].Value;

            set => Column["AudioEventGUID_OfferDeny"].Value = value;
        }

        public string AudioEventGUID_Completed
        {
            get => (string) Column["AudioEventGUID_Completed"].Value;

            set => Column["AudioEventGUID_Completed"].Value = value;
        }

        public string AudioEventGUID_TurnIn
        {
            get => (string) Column["AudioEventGUID_TurnIn"].Value;

            set => Column["AudioEventGUID_TurnIn"].Value = value;
        }

        public string AudioEventGUID_Failed
        {
            get => (string) Column["AudioEventGUID_Failed"].Value;

            set => Column["AudioEventGUID_Failed"].Value = value;
        }

        public string AudioEventGUID_Progress
        {
            get => (string) Column["AudioEventGUID_Progress"].Value;

            set => Column["AudioEventGUID_Progress"].Value = value;
        }

        public string AudioMusicCue_OfferAccept
        {
            get => (string) Column["AudioMusicCue_OfferAccept"].Value;

            set => Column["AudioMusicCue_OfferAccept"].Value = value;
        }

        public string AudioMusicCue_TurnIn
        {
            get => (string) Column["AudioMusicCue_TurnIn"].Value;

            set => Column["AudioMusicCue_TurnIn"].Value = value;
        }

        public int turnInIconID
        {
            get => (int) Column["turnInIconID"].Value;

            set => Column["turnInIconID"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}