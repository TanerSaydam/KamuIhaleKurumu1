import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideStore } from '@ngrx/store';
import { countRecuder } from './store/count.reducer';
import { count2Reducer } from './store/count2.reducer';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), 
    provideStore({count: countRecuder, num: count2Reducer})]
};