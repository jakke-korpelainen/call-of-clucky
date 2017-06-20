using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private float rateOfFire;

    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private Transform Hand;

    private WeaponReloader reloader;
    private float nextFireAllowed;
    private Transform muzzle;

    public bool canFire;

    void Awake()
    {
        muzzle = transform.Find("Muzzle");
        reloader = GetComponent<WeaponReloader>();

        transform.SetParent(Hand);
    }

    public void Reload()
    {
        if (reloader == null)
            return;

        reloader.Reload();
    }

    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        if (reloader == null || reloader.IsReloading || reloader.RoundsRemainingInClip == 0)
            return;
        else
            reloader.TakeFromClip(1);

        nextFireAllowed = Time.time + rateOfFire;

        // instantiate the projectile
        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
    }
}
