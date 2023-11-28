import { createAction, props } from "@ngrx/store";

export const increment = createAction(
    "My Action",
    props<{num: number}>()
)

export const decrement = createAction(
    "My Action 2",
    props<{num: number}>()
)