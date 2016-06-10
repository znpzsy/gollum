import {Component} from '@angular/core';

@Component({
  selector: 'home',
  template: `
    <h1>Welcome to Gollum</h1>

    <p> To try out brokered authentication with Auth0, trace the ping component.    
    </p>
   <p>See also: <code>auth/auth.service.ts</code>.</p>
  `
})
export class Home {

  constructor() {}

}
