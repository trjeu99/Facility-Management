import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CarListComponent } from "./car/car-list.component";
import { CarEditComponent } from "./car/car-edit.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: "car",
                        component: CarListComponent,
                        data: { permission: "Pages.Group0.Car" },
                    },
                    {
                        path: "car-add",
                        component: CarEditComponent,
                        data: {
                            permission: "Pages.Group0.Car.Add",
                            editPageState: "add",
                        },
                    },
                    {
                        path: "car-edit",
                        component: CarEditComponent,
                        data: {
                            permission: "Pages.Group0.Car.Update",
                            editPageState: "edit",
                        },
                    },
                    {
                        path: "car-view",
                        component: CarEditComponent,
                        data: {
                            permission: "Pages.Group0.Car.View",
                            editPageState: "view",
                        },
                    },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class Group0RoutingModule {}
