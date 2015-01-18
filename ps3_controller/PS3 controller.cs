using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApplication1
{
    class Program
    {
        // Creates a device for the controller for the computer
        private void Device()
        {
            foreach(DeviceInstance di in Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly))
            {
                controller = new Device(di.InstanceGuid);
                break;
            }

            // if device not found, an exception is thrown out

            if (controller == null)
                throw new Exception("No controller was found. Please connect one.");
            
        }

        static void Main(string[] args)
        {
            // Sets the axis range for the controller
            foreach (DeviceObjectInstance doi in controller.Objects)
            {
                if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    controller.Properties.SetRange(
                        ParameterHow.ById,
                        doi.ObjectId,
                        new InputRange(-5000, 5000));
                }
            }
            // sets the axis mode for the controller
            controller.Properties.AxisModeAbsolute = true;

            controller.SetCooperativelevel(this, CooperativeLevelFlags.NonExclusive | CooperativeLevelFlags.Background);

            // Acquires the controller
            controller.Acquire();
           }

            private void Updatecontroller()
            {
                 string info = "controller: ";
				
                 // obtain the mouse state of the controller.
                 controllerState state = joystick.CurrentJoystickState;

                 // retrieve the position of the controller.
                info += "X:" + state.X + " ";
                info += "Y:" + state.Y + " ";
                info += "Z:" + state.Z + " ";

                // retrive the buttons of the controller.
             byte[] buttons = state.GetButtons();
             for(int i = 0; i < buttons.Length; i++)
             {
                 if(buttons[i] != 0)
                 {
                     info += "Button:" + i + " ";
                 }
             }

                lbcontroller.Text = info;
           }


        }
    }

