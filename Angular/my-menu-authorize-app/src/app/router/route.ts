export class RouteModel{   
    path: string = "";
    name: string = "";
    icon: string = "";
    isAuthorize: boolean = true;
    authorizeName: string = "";
    title: string = "";
    isHaveChild: boolean = false;
    childRoutes: RouteModel[] = []
}

export const Menus: RouteModel[] = [
    {
        path: "/",
        name: "Home",
        icon: "fa fa-home",
        authorizeName: "Menu.Home",
        isAuthorize: true,
        isHaveChild: false,
        title: "Home Page",
        childRoutes: []
    },
    {
        path: "/personel",
        name: "Personel",        
        authorizeName: "Menu.Personel",
        icon: "fa fa-file",
        isAuthorize: true,
        isHaveChild: false,
        title: "Personel Page",
        childRoutes: [] 
    },
    {
        path: "/blogs",
        name: "Blog",
        icon: "fa fa-box",
        authorizeName: "Menu.Blog",
        isAuthorize: true,
        isHaveChild: true,
        title: "Blog Page",
        childRoutes: [
            {
                path: "/blogs/create",
                name: "Create Blog",
                icon: "fa fa-file",
                authorizeName: "Menu.Blog.Create",
                isAuthorize: true,
                isHaveChild: true,
                title: "Create Blog Page",
                childRoutes: [
                    {
                        path: "/blogs/create",
                        name: "Create Blog",
                        authorizeName: "Menu.Blog.Create",
                        icon: "fa fa-file",
                        isAuthorize: true,
                        isHaveChild: true,
                        title: "Create Blog Page",
                        childRoutes: [
                            {
                                path: "/blogs/create",
                                name: "Create Blog",
                                authorizeName: "Menu.Blog.Create",
                                icon: "fa fa-file",
                                isAuthorize: true,
                                isHaveChild: false,
                                title: "Create Blog Page",
                                childRoutes: []  
                            },
                        ]  
                    },
                ]  
            },
            {
                path: "/blogs/list",
                name: "List Blog",
                authorizeName: "Menu.Blog.List",
                icon: "fa fa-file",
                isAuthorize: true,
                isHaveChild: false,
                title: "List Blog Page",
                childRoutes: []  
            }
        ] 
    }
]