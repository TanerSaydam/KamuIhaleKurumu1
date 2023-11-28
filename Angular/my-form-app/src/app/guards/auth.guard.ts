import { CanDeactivateFn } from '@angular/router';

export const authGuard: CanDeactivateFn<unknown> = (component, currentRoute, currentState, nextState) => {
  return true;
};
