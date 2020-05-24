import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CarProposalComponent } from "./car-proposal/car-proposal.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: "car-add",
                        component: CarProposalComponent,
                        data: {

                        },
                    },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class Group1RoutingModule { }
