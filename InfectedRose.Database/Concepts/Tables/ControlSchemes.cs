namespace InfectedRose.Database.Concepts.Tables
{
    public class ControlSchemesTable

    {
        public ControlSchemesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int control_scheme
        {
            get => (int) Column["control_scheme"].Value;

            set => Column["control_scheme"].Value = value;
        }

        public string scheme_name
        {
            get => (string) Column["scheme_name"].Value;

            set => Column["scheme_name"].Value = value;
        }

        public float rotation_speed
        {
            get => (float) Column["rotation_speed"].Value;

            set => Column["rotation_speed"].Value = value;
        }

        public float walk_forward_speed
        {
            get => (float) Column["walk_forward_speed"].Value;

            set => Column["walk_forward_speed"].Value = value;
        }

        public float walk_backward_speed
        {
            get => (float) Column["walk_backward_speed"].Value;

            set => Column["walk_backward_speed"].Value = value;
        }

        public float walk_strafe_speed
        {
            get => (float) Column["walk_strafe_speed"].Value;

            set => Column["walk_strafe_speed"].Value = value;
        }

        public float walk_strafe_forward_speed
        {
            get => (float) Column["walk_strafe_forward_speed"].Value;

            set => Column["walk_strafe_forward_speed"].Value = value;
        }

        public float walk_strafe_backward_speed
        {
            get => (float) Column["walk_strafe_backward_speed"].Value;

            set => Column["walk_strafe_backward_speed"].Value = value;
        }

        public float run_backward_speed
        {
            get => (float) Column["run_backward_speed"].Value;

            set => Column["run_backward_speed"].Value = value;
        }

        public float run_strafe_speed
        {
            get => (float) Column["run_strafe_speed"].Value;

            set => Column["run_strafe_speed"].Value = value;
        }

        public float run_strafe_forward_speed
        {
            get => (float) Column["run_strafe_forward_speed"].Value;

            set => Column["run_strafe_forward_speed"].Value = value;
        }

        public float run_strafe_backward_speed
        {
            get => (float) Column["run_strafe_backward_speed"].Value;

            set => Column["run_strafe_backward_speed"].Value = value;
        }

        public float keyboard_zoom_sensitivity
        {
            get => (float) Column["keyboard_zoom_sensitivity"].Value;

            set => Column["keyboard_zoom_sensitivity"].Value = value;
        }

        public float keyboard_pitch_sensitivity
        {
            get => (float) Column["keyboard_pitch_sensitivity"].Value;

            set => Column["keyboard_pitch_sensitivity"].Value = value;
        }

        public float keyboard_yaw_sensitivity
        {
            get => (float) Column["keyboard_yaw_sensitivity"].Value;

            set => Column["keyboard_yaw_sensitivity"].Value = value;
        }

        public float mouse_zoom_wheel_sensitivity
        {
            get => (float) Column["mouse_zoom_wheel_sensitivity"].Value;

            set => Column["mouse_zoom_wheel_sensitivity"].Value = value;
        }

        public float x_mouse_move_sensitivity_modifier
        {
            get => (float) Column["x_mouse_move_sensitivity_modifier"].Value;

            set => Column["x_mouse_move_sensitivity_modifier"].Value = value;
        }

        public float y_mouse_move_sensitivity_modifier
        {
            get => (float) Column["y_mouse_move_sensitivity_modifier"].Value;

            set => Column["y_mouse_move_sensitivity_modifier"].Value = value;
        }

        public float freecam_speed_modifier
        {
            get => (float) Column["freecam_speed_modifier"].Value;

            set => Column["freecam_speed_modifier"].Value = value;
        }

        public float freecam_slow_speed_multiplier
        {
            get => (float) Column["freecam_slow_speed_multiplier"].Value;

            set => Column["freecam_slow_speed_multiplier"].Value = value;
        }

        public float freecam_fast_speed_multiplier
        {
            get => (float) Column["freecam_fast_speed_multiplier"].Value;

            set => Column["freecam_fast_speed_multiplier"].Value = value;
        }

        public float freecam_mouse_modifier
        {
            get => (float) Column["freecam_mouse_modifier"].Value;

            set => Column["freecam_mouse_modifier"].Value = value;
        }

        public float gamepad_pitch_rot_sensitivity
        {
            get => (float) Column["gamepad_pitch_rot_sensitivity"].Value;

            set => Column["gamepad_pitch_rot_sensitivity"].Value = value;
        }

        public float gamepad_yaw_rot_sensitivity
        {
            get => (float) Column["gamepad_yaw_rot_sensitivity"].Value;

            set => Column["gamepad_yaw_rot_sensitivity"].Value = value;
        }

        public float gamepad_trigger_sensitivity
        {
            get => (float) Column["gamepad_trigger_sensitivity"].Value;

            set => Column["gamepad_trigger_sensitivity"].Value = value;
        }
    }
}