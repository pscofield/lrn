using System;

namespace TheDecoratorPattern
{
    internal class DellStudioModel : Computer
    {
        internal override double GetCost()
        {
            return ConstantCosts.DellStudio;
        }

        internal DellStudioModel()
        {
            Description = "DS";
        }

    }

    internal class DellInspironModel : Computer
    {
        internal override double GetCost()
        {
            return ConstantCosts.DellInspiron;
        }

        internal DellInspironModel()
        {
            Description = "DI";
        }
    }

    internal class UsbMouseAccessory : ComputerAccessory
    {
        internal UsbMouseAccessory(Computer computer)
        {
            BaseComputer = computer;
        }

        internal override double GetCost()
        {
            return (BaseComputer.GetCost() + ConstantCosts.UsbMouse);
        }

        internal override string GetDescription()
        {
            return BaseComputer.GetDescription() + ", USB Mouse";
        }
    }

    internal class UsbKeyboardAccessory : ComputerAccessory
    {
        internal UsbKeyboardAccessory(Computer computer)
        {
            BaseComputer = computer;
        }

        internal override double GetCost()
        {
            return (BaseComputer.GetCost() + ConstantCosts.UsbKeyboard);
        }

        internal override string GetDescription()
        {
            return BaseComputer.GetDescription() + ", USB Keyboard";
        }
    }

    internal class GraphicsCardAccessory : ComputerAccessory
    {
        internal GraphicsCardAccessory(Computer computer)
        {
            BaseComputer = computer;
        }

        internal override double GetCost()
        {
            return (BaseComputer.GetCost() + ConstantCosts.GraphicsCard);
        }

        internal override string GetDescription()
        {
            return BaseComputer.GetDescription() + ", Graphics Card";
        }
    }

    internal class ExternalHddAccessory : ComputerAccessory
    {
        internal ExternalHddAccessory(Computer computer)
        {
            BaseComputer = computer;
        }

        internal override double GetCost()
        {
            return (BaseComputer.GetCost() + ConstantCosts.ExternalHdd);
        }

        internal override string GetDescription()
        {
            return BaseComputer.GetDescription() + ", External HDD";
        }
    }
    internal class DvdDriveAccessory : ComputerAccessory
    {
        internal DvdDriveAccessory(Computer computer)
        {
            BaseComputer = computer;
        }

        internal override double GetCost()
        {
            return (BaseComputer.GetCost() + ConstantCosts.DvdDrive);
        }

        internal override string GetDescription()
        {
            return BaseComputer.GetDescription() + ", DVD Drive";
        }
    }
}