import { Component, EventEmitter, Input, Output } from "@angular/core";
import { TodoModel } from "../todo.model";

@Component({
    selector: "app-list",
    templateUrl: "./app-list.component.html",
    styleUrls: ["./app-list.component.css"]
})
export class AppListComponent {
    @Input() todos: TodoModel[] = [];
    isUpdateFormActive: boolean = false;

    @Output() removeEvent = new EventEmitter<number>();

    get(index: number) {

    }

    removeByIndex(index: number) {
        this.removeEvent.emit(index);
    }

    changeColorWithCompleted(completed: boolean) {
        if (completed) return 'black';

        return 'red';
    }
}