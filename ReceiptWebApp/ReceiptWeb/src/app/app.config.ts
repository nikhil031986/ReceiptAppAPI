import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient,withFetch } from '@angular/common/http';
import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';


export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), 
        provideRouter(routes),
        provideAnimations(),
        provideToastr({
                timeOut: 3000,
                positionClass: 'toast-top-right',
    }), provideHttpClient(withFetch()), provideClientHydration(withEventReplay())]
};
