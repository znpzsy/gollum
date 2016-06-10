import {Injectable, NgZone} from '@angular/core';
import {Router} from '@angular/router-deprecated';
import {AuthHttp, tokenNotExpired} from 'angular2-jwt';

// Avoid name not found warnings
declare var Auth0Lock: any;

@Injectable()
export class Auth {
    private cId: string = 'LspPoiDLAOSb7VZlpcUoguHeLwIXaG5F';
    private domain: string = 'gollum.auth0.com';
    refreshSubscription: any;
    user: Object;
    zoneImpl: NgZone;

    constructor(private authHttp: AuthHttp, zone: NgZone, private router: Router) {

        this.zoneImpl = zone;
        this.user = JSON.parse(localStorage.getItem('profile'));
    }

    public authenticated() {
        // Check if there's an unexpired JWT
        return tokenNotExpired();
    }

    public login() {
        var lock = new Auth0Lock(this.cId, this.domain);
        var options = {
            primaryColor: '#7123ea',
            connections: ['auth0', 'facebook', 'linkedin', 'google-oAuth2']
        };

        //// or both options and callback
        //lock.showSignin(options, function (err, profile, token) { });
        // Show the Auth0 Lock widget
        lock.show({}, (err, profile, token) => {
            if (err) {
                alert(err);
                return;
            }
            // If authentication is successful, save the items
            // in local storage
            localStorage.setItem('profile', JSON.stringify(profile));
            localStorage.setItem('id_token', token);
            this.zoneImpl.run(() => this.user = profile);

        });
    }

    public logout() {
        localStorage.removeItem('profile');
        localStorage.removeItem('id_token');
        this.zoneImpl.run(() => this.user = null);
        this.router.navigate(['Home']);
    }
}
