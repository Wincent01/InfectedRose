namespace InfectedRose.Database.Concepts.Tables
{
    public class CameraTable

    {
        public CameraTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string camera_name
        {
            get => (string) Column["camera_name"].Value;

            set => Column["camera_name"].Value = value;
        }

        public float pitch_angle_tolerance
        {
            get => (float) Column["pitch_angle_tolerance"].Value;

            set => Column["pitch_angle_tolerance"].Value = value;
        }

        public float starting_zoom
        {
            get => (float) Column["starting_zoom"].Value;

            set => Column["starting_zoom"].Value = value;
        }

        public float zoom_return_modifier
        {
            get => (float) Column["zoom_return_modifier"].Value;

            set => Column["zoom_return_modifier"].Value = value;
        }

        public float pitch_return_modifier
        {
            get => (float) Column["pitch_return_modifier"].Value;

            set => Column["pitch_return_modifier"].Value = value;
        }

        public float tether_out_return_modifier
        {
            get => (float) Column["tether_out_return_modifier"].Value;

            set => Column["tether_out_return_modifier"].Value = value;
        }

        public float tether_in_return_multiplier
        {
            get => (float) Column["tether_in_return_multiplier"].Value;

            set => Column["tether_in_return_multiplier"].Value = value;
        }

        public float verticle_movement_dampening_modifier
        {
            get => (float) Column["verticle_movement_dampening_modifier"].Value;

            set => Column["verticle_movement_dampening_modifier"].Value = value;
        }

        public float return_from_incline_modifier
        {
            get => (float) Column["return_from_incline_modifier"].Value;

            set => Column["return_from_incline_modifier"].Value = value;
        }

        public float horizontal_return_modifier
        {
            get => (float) Column["horizontal_return_modifier"].Value;

            set => Column["horizontal_return_modifier"].Value = value;
        }

        public float yaw_behavior_speed_multiplier
        {
            get => (float) Column["yaw_behavior_speed_multiplier"].Value;

            set => Column["yaw_behavior_speed_multiplier"].Value = value;
        }

        public float camera_collision_padding
        {
            get => (float) Column["camera_collision_padding"].Value;

            set => Column["camera_collision_padding"].Value = value;
        }

        public float glide_speed
        {
            get => (float) Column["glide_speed"].Value;

            set => Column["glide_speed"].Value = value;
        }

        public float fade_player_min_range
        {
            get => (float) Column["fade_player_min_range"].Value;

            set => Column["fade_player_min_range"].Value = value;
        }

        public float min_movement_delta_tolerance
        {
            get => (float) Column["min_movement_delta_tolerance"].Value;

            set => Column["min_movement_delta_tolerance"].Value = value;
        }

        public float min_glide_distance_tolerance
        {
            get => (float) Column["min_glide_distance_tolerance"].Value;

            set => Column["min_glide_distance_tolerance"].Value = value;
        }

        public float look_forward_offset
        {
            get => (float) Column["look_forward_offset"].Value;

            set => Column["look_forward_offset"].Value = value;
        }

        public float look_up_offset
        {
            get => (float) Column["look_up_offset"].Value;

            set => Column["look_up_offset"].Value = value;
        }

        public float minimum_vertical_dampening_distance
        {
            get => (float) Column["minimum_vertical_dampening_distance"].Value;

            set => Column["minimum_vertical_dampening_distance"].Value = value;
        }

        public float maximum_vertical_dampening_distance
        {
            get => (float) Column["maximum_vertical_dampening_distance"].Value;

            set => Column["maximum_vertical_dampening_distance"].Value = value;
        }

        public float minimum_ignore_jump_distance
        {
            get => (float) Column["minimum_ignore_jump_distance"].Value;

            set => Column["minimum_ignore_jump_distance"].Value = value;
        }

        public float maximum_ignore_jump_distance
        {
            get => (float) Column["maximum_ignore_jump_distance"].Value;

            set => Column["maximum_ignore_jump_distance"].Value = value;
        }

        public float maximum_auto_glide_angle
        {
            get => (float) Column["maximum_auto_glide_angle"].Value;

            set => Column["maximum_auto_glide_angle"].Value = value;
        }

        public float minimum_tether_glide_distance
        {
            get => (float) Column["minimum_tether_glide_distance"].Value;

            set => Column["minimum_tether_glide_distance"].Value = value;
        }

        public float yaw_sign_correction
        {
            get => (float) Column["yaw_sign_correction"].Value;

            set => Column["yaw_sign_correction"].Value = value;
        }

        public float set_1_look_forward_offset
        {
            get => (float) Column["set_1_look_forward_offset"].Value;

            set => Column["set_1_look_forward_offset"].Value = value;
        }

        public float set_1_look_up_offset
        {
            get => (float) Column["set_1_look_up_offset"].Value;

            set => Column["set_1_look_up_offset"].Value = value;
        }

        public float set_2_look_forward_offset
        {
            get => (float) Column["set_2_look_forward_offset"].Value;

            set => Column["set_2_look_forward_offset"].Value = value;
        }

        public float set_2_look_up_offset
        {
            get => (float) Column["set_2_look_up_offset"].Value;

            set => Column["set_2_look_up_offset"].Value = value;
        }

        public float set_0_speed_influence_on_dir
        {
            get => (float) Column["set_0_speed_influence_on_dir"].Value;

            set => Column["set_0_speed_influence_on_dir"].Value = value;
        }

        public float set_1_speed_influence_on_dir
        {
            get => (float) Column["set_1_speed_influence_on_dir"].Value;

            set => Column["set_1_speed_influence_on_dir"].Value = value;
        }

        public float set_2_speed_influence_on_dir
        {
            get => (float) Column["set_2_speed_influence_on_dir"].Value;

            set => Column["set_2_speed_influence_on_dir"].Value = value;
        }

        public float set_0_angular_relaxation
        {
            get => (float) Column["set_0_angular_relaxation"].Value;

            set => Column["set_0_angular_relaxation"].Value = value;
        }

        public float set_1_angular_relaxation
        {
            get => (float) Column["set_1_angular_relaxation"].Value;

            set => Column["set_1_angular_relaxation"].Value = value;
        }

        public float set_2_angular_relaxation
        {
            get => (float) Column["set_2_angular_relaxation"].Value;

            set => Column["set_2_angular_relaxation"].Value = value;
        }

        public float set_0_position_up_offset
        {
            get => (float) Column["set_0_position_up_offset"].Value;

            set => Column["set_0_position_up_offset"].Value = value;
        }

        public float set_1_position_up_offset
        {
            get => (float) Column["set_1_position_up_offset"].Value;

            set => Column["set_1_position_up_offset"].Value = value;
        }

        public float set_2_position_up_offset
        {
            get => (float) Column["set_2_position_up_offset"].Value;

            set => Column["set_2_position_up_offset"].Value = value;
        }

        public float set_0_position_forward_offset
        {
            get => (float) Column["set_0_position_forward_offset"].Value;

            set => Column["set_0_position_forward_offset"].Value = value;
        }

        public float set_1_position_forward_offset
        {
            get => (float) Column["set_1_position_forward_offset"].Value;

            set => Column["set_1_position_forward_offset"].Value = value;
        }

        public float set_2_position_forward_offset
        {
            get => (float) Column["set_2_position_forward_offset"].Value;

            set => Column["set_2_position_forward_offset"].Value = value;
        }

        public float set_0_FOV
        {
            get => (float) Column["set_0_FOV"].Value;

            set => Column["set_0_FOV"].Value = value;
        }

        public float set_1_FOV
        {
            get => (float) Column["set_1_FOV"].Value;

            set => Column["set_1_FOV"].Value = value;
        }

        public float set_2_FOV
        {
            get => (float) Column["set_2_FOV"].Value;

            set => Column["set_2_FOV"].Value = value;
        }

        public float set_0_max_yaw_angle
        {
            get => (float) Column["set_0_max_yaw_angle"].Value;

            set => Column["set_0_max_yaw_angle"].Value = value;
        }

        public float set_1_max_yaw_angle
        {
            get => (float) Column["set_1_max_yaw_angle"].Value;

            set => Column["set_1_max_yaw_angle"].Value = value;
        }

        public float set_2_max_yaw_angle
        {
            get => (float) Column["set_2_max_yaw_angle"].Value;

            set => Column["set_2_max_yaw_angle"].Value = value;
        }

        public int set_1_fade_in_camera_set_change
        {
            get => (int) Column["set_1_fade_in_camera_set_change"].Value;

            set => Column["set_1_fade_in_camera_set_change"].Value = value;
        }

        public int set_1_fade_out_camera_set_change
        {
            get => (int) Column["set_1_fade_out_camera_set_change"].Value;

            set => Column["set_1_fade_out_camera_set_change"].Value = value;
        }

        public int set_2_fade_in_camera_set_change
        {
            get => (int) Column["set_2_fade_in_camera_set_change"].Value;

            set => Column["set_2_fade_in_camera_set_change"].Value = value;
        }

        public int set_2_fade_out_camera_set_change
        {
            get => (int) Column["set_2_fade_out_camera_set_change"].Value;

            set => Column["set_2_fade_out_camera_set_change"].Value = value;
        }

        public float input_movement_scalar
        {
            get => (float) Column["input_movement_scalar"].Value;

            set => Column["input_movement_scalar"].Value = value;
        }

        public float input_rotation_scalar
        {
            get => (float) Column["input_rotation_scalar"].Value;

            set => Column["input_rotation_scalar"].Value = value;
        }

        public float input_zoom_scalar
        {
            get => (float) Column["input_zoom_scalar"].Value;

            set => Column["input_zoom_scalar"].Value = value;
        }

        public float minimum_pitch_desired
        {
            get => (float) Column["minimum_pitch_desired"].Value;

            set => Column["minimum_pitch_desired"].Value = value;
        }

        public float maximum_pitch_desired
        {
            get => (float) Column["maximum_pitch_desired"].Value;

            set => Column["maximum_pitch_desired"].Value = value;
        }

        public float minimum_zoom
        {
            get => (float) Column["minimum_zoom"].Value;

            set => Column["minimum_zoom"].Value = value;
        }

        public float maximum_zoom
        {
            get => (float) Column["maximum_zoom"].Value;

            set => Column["maximum_zoom"].Value = value;
        }

        public float horizontal_rotate_tolerance
        {
            get => (float) Column["horizontal_rotate_tolerance"].Value;

            set => Column["horizontal_rotate_tolerance"].Value = value;
        }

        public float horizontal_rotate_modifier
        {
            get => (float) Column["horizontal_rotate_modifier"].Value;

            set => Column["horizontal_rotate_modifier"].Value = value;
        }
    }
}