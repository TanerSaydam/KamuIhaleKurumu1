import { createReducer, on } from "@ngrx/store";
import { decrement, increment } from "./count.actions";


export const initialState: number = 0;
export const countRecuder = createReducer(
    initialState,
    on(increment, (state)=> state + 1),
    on(decrement, (state)=> state -1)
)