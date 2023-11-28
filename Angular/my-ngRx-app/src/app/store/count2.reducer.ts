import { createReducer, on } from "@ngrx/store";
import { decrement, increment } from "./count2.action";

export const initialState: number = 0;

export const count2Reducer = createReducer(
    initialState,
    on(increment, (state, {num})=> {
        //işlemler
        return  (state) + (+num); //"5" 5
    }),
    on(decrement,(state, {num})=> (state) - (+num))
)