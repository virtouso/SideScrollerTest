namespace Mvc.Example
{
    public interface IWeaponController
    {
    }

    public class WeaponController<T> : BaseController<T>, IWeaponController
        where T : WeaponModel
    {
        public bool HasNoCooldown(float currentTime)
        {
            if (currentTime >= Model.NextShotAvailable)
            {
                Model.NextShotAvailable = currentTime + Model.shotCooldown;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShootTrigger(bool isPressed, float currentTime)
        {
            bool doShoot = false;

            if (Model.isSingleShot && isPressed && !Model.isTriggerDown)
            {
                if (HasNoCooldown(currentTime))
                {
                    doShoot = true;
                }
            }
            else if (!Model.isSingleShot && isPressed)
            {
                if (HasNoCooldown(currentTime))
                {
                    doShoot = true;
                }
            }

            Model.isTriggerDown = isPressed;
            return doShoot;
        }
    }
}