import { createAction } from "@ngrx/store";

export const increment = createAction('[Counter] increment counter');

export const decrement = createAction("[Counter] decrement counter");