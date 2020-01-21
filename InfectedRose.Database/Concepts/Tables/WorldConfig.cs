namespace InfectedRose.Database.Concepts.Tables
{
    public class WorldConfigTable

    {
        public WorldConfigTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int WorldConfigID
        {
            get => (int) Column["WorldConfigID"].Value;

            set => Column["WorldConfigID"].Value = value;
        }

        public float pegravityvalue
        {
            get => (float) Column["pegravityvalue"].Value;

            set => Column["pegravityvalue"].Value = value;
        }

        public float pebroadphaseworldsize
        {
            get => (float) Column["pebroadphaseworldsize"].Value;

            set => Column["pebroadphaseworldsize"].Value = value;
        }

        public float pegameobjscalefactor
        {
            get => (float) Column["pegameobjscalefactor"].Value;

            set => Column["pegameobjscalefactor"].Value = value;
        }

        public float character_rotation_speed
        {
            get => (float) Column["character_rotation_speed"].Value;

            set => Column["character_rotation_speed"].Value = value;
        }

        public float character_walk_forward_speed
        {
            get => (float) Column["character_walk_forward_speed"].Value;

            set => Column["character_walk_forward_speed"].Value = value;
        }

        public float character_walk_backward_speed
        {
            get => (float) Column["character_walk_backward_speed"].Value;

            set => Column["character_walk_backward_speed"].Value = value;
        }

        public float character_walk_strafe_speed
        {
            get => (float) Column["character_walk_strafe_speed"].Value;

            set => Column["character_walk_strafe_speed"].Value = value;
        }

        public float character_walk_strafe_forward_speed
        {
            get => (float) Column["character_walk_strafe_forward_speed"].Value;

            set => Column["character_walk_strafe_forward_speed"].Value = value;
        }

        public float character_walk_strafe_backward_speed
        {
            get => (float) Column["character_walk_strafe_backward_speed"].Value;

            set => Column["character_walk_strafe_backward_speed"].Value = value;
        }

        public float character_run_backward_speed
        {
            get => (float) Column["character_run_backward_speed"].Value;

            set => Column["character_run_backward_speed"].Value = value;
        }

        public float character_run_strafe_speed
        {
            get => (float) Column["character_run_strafe_speed"].Value;

            set => Column["character_run_strafe_speed"].Value = value;
        }

        public float character_run_strafe_forward_speed
        {
            get => (float) Column["character_run_strafe_forward_speed"].Value;

            set => Column["character_run_strafe_forward_speed"].Value = value;
        }

        public float character_run_strafe_backward_speed
        {
            get => (float) Column["character_run_strafe_backward_speed"].Value;

            set => Column["character_run_strafe_backward_speed"].Value = value;
        }

        public float global_cooldown
        {
            get => (float) Column["global_cooldown"].Value;

            set => Column["global_cooldown"].Value = value;
        }

        public float characterGroundedTime
        {
            get => (float) Column["characterGroundedTime"].Value;

            set => Column["characterGroundedTime"].Value = value;
        }

        public float characterGroundedSpeed
        {
            get => (float) Column["characterGroundedSpeed"].Value;

            set => Column["characterGroundedSpeed"].Value = value;
        }

        public float globalImmunityTime
        {
            get => (float) Column["globalImmunityTime"].Value;

            set => Column["globalImmunityTime"].Value = value;
        }

        public float character_max_slope
        {
            get => (float) Column["character_max_slope"].Value;

            set => Column["character_max_slope"].Value = value;
        }

        public float defaultrespawntime
        {
            get => (float) Column["defaultrespawntime"].Value;

            set => Column["defaultrespawntime"].Value = value;
        }

        public float mission_tooltip_timeout
        {
            get => (float) Column["mission_tooltip_timeout"].Value;

            set => Column["mission_tooltip_timeout"].Value = value;
        }

        public float vendor_buy_multiplier
        {
            get => (float) Column["vendor_buy_multiplier"].Value;

            set => Column["vendor_buy_multiplier"].Value = value;
        }

        public float pet_follow_radius
        {
            get => (float) Column["pet_follow_radius"].Value;

            set => Column["pet_follow_radius"].Value = value;
        }

        public float character_eye_height
        {
            get => (float) Column["character_eye_height"].Value;

            set => Column["character_eye_height"].Value = value;
        }

        public float flight_vertical_velocity
        {
            get => (float) Column["flight_vertical_velocity"].Value;

            set => Column["flight_vertical_velocity"].Value = value;
        }

        public float flight_airspeed
        {
            get => (float) Column["flight_airspeed"].Value;

            set => Column["flight_airspeed"].Value = value;
        }

        public float flight_fuel_ratio
        {
            get => (float) Column["flight_fuel_ratio"].Value;

            set => Column["flight_fuel_ratio"].Value = value;
        }

        public float flight_max_airspeed
        {
            get => (float) Column["flight_max_airspeed"].Value;

            set => Column["flight_max_airspeed"].Value = value;
        }

        public float fReputationPerVote
        {
            get => (float) Column["fReputationPerVote"].Value;

            set => Column["fReputationPerVote"].Value = value;
        }

        public int nPropertyCloneLimit
        {
            get => (int) Column["nPropertyCloneLimit"].Value;

            set => Column["nPropertyCloneLimit"].Value = value;
        }

        public int defaultHomespaceTemplate
        {
            get => (int) Column["defaultHomespaceTemplate"].Value;

            set => Column["defaultHomespaceTemplate"].Value = value;
        }

        public float coins_lost_on_death_percent
        {
            get => (float) Column["coins_lost_on_death_percent"].Value;

            set => Column["coins_lost_on_death_percent"].Value = value;
        }

        public int coins_lost_on_death_min
        {
            get => (int) Column["coins_lost_on_death_min"].Value;

            set => Column["coins_lost_on_death_min"].Value = value;
        }

        public int coins_lost_on_death_max
        {
            get => (int) Column["coins_lost_on_death_max"].Value;

            set => Column["coins_lost_on_death_max"].Value = value;
        }

        public int character_votes_per_day
        {
            get => (int) Column["character_votes_per_day"].Value;

            set => Column["character_votes_per_day"].Value = value;
        }

        public int property_moderation_request_approval_cost
        {
            get => (int) Column["property_moderation_request_approval_cost"].Value;

            set => Column["property_moderation_request_approval_cost"].Value = value;
        }

        public int property_moderation_request_review_cost
        {
            get => (int) Column["property_moderation_request_review_cost"].Value;

            set => Column["property_moderation_request_review_cost"].Value = value;
        }

        public int propertyModRequestsAllowedSpike
        {
            get => (int) Column["propertyModRequestsAllowedSpike"].Value;

            set => Column["propertyModRequestsAllowedSpike"].Value = value;
        }

        public int propertyModRequestsAllowedInterval
        {
            get => (int) Column["propertyModRequestsAllowedInterval"].Value;

            set => Column["propertyModRequestsAllowedInterval"].Value = value;
        }

        public int propertyModRequestsAllowedTotal
        {
            get => (int) Column["propertyModRequestsAllowedTotal"].Value;

            set => Column["propertyModRequestsAllowedTotal"].Value = value;
        }

        public int propertyModRequestsSpikeDuration
        {
            get => (int) Column["propertyModRequestsSpikeDuration"].Value;

            set => Column["propertyModRequestsSpikeDuration"].Value = value;
        }

        public int propertyModRequestsIntervalDuration
        {
            get => (int) Column["propertyModRequestsIntervalDuration"].Value;

            set => Column["propertyModRequestsIntervalDuration"].Value = value;
        }

        public bool modelModerateOnCreate
        {
            get => (bool) Column["modelModerateOnCreate"].Value;

            set => Column["modelModerateOnCreate"].Value = value;
        }

        public float defaultPropertyMaxHeight
        {
            get => (float) Column["defaultPropertyMaxHeight"].Value;

            set => Column["defaultPropertyMaxHeight"].Value = value;
        }

        public float reputationPerVoteCast
        {
            get => (float) Column["reputationPerVoteCast"].Value;

            set => Column["reputationPerVoteCast"].Value = value;
        }

        public float reputationPerVoteReceived
        {
            get => (float) Column["reputationPerVoteReceived"].Value;

            set => Column["reputationPerVoteReceived"].Value = value;
        }

        public int showcaseTopModelConsiderationBattles
        {
            get => (int) Column["showcaseTopModelConsiderationBattles"].Value;

            set => Column["showcaseTopModelConsiderationBattles"].Value = value;
        }

        public float reputationPerBattlePromotion
        {
            get => (float) Column["reputationPerBattlePromotion"].Value;

            set => Column["reputationPerBattlePromotion"].Value = value;
        }

        public float coins_lost_on_death_min_timeout
        {
            get => (float) Column["coins_lost_on_death_min_timeout"].Value;

            set => Column["coins_lost_on_death_min_timeout"].Value = value;
        }

        public float coins_lost_on_death_max_timeout
        {
            get => (float) Column["coins_lost_on_death_max_timeout"].Value;

            set => Column["coins_lost_on_death_max_timeout"].Value = value;
        }

        public int mail_base_fee
        {
            get => (int) Column["mail_base_fee"].Value;

            set => Column["mail_base_fee"].Value = value;
        }

        public float mail_percent_attachment_fee
        {
            get => (float) Column["mail_percent_attachment_fee"].Value;

            set => Column["mail_percent_attachment_fee"].Value = value;
        }

        public int propertyReputationDelay
        {
            get => (int) Column["propertyReputationDelay"].Value;

            set => Column["propertyReputationDelay"].Value = value;
        }

        public int LevelCap
        {
            get => (int) Column["LevelCap"].Value;

            set => Column["LevelCap"].Value = value;
        }

        public string LevelUpBehaviorEffect
        {
            get => (string) Column["LevelUpBehaviorEffect"].Value;

            set => Column["LevelUpBehaviorEffect"].Value = value;
        }

        public int CharacterVersion
        {
            get => (int) Column["CharacterVersion"].Value;

            set => Column["CharacterVersion"].Value = value;
        }

        public int LevelCapCurrencyConversion
        {
            get => (int) Column["LevelCapCurrencyConversion"].Value;

            set => Column["LevelCapCurrencyConversion"].Value = value;
        }
    }
}