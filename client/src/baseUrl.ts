import {TodoClient} from "./generated-ts-client.ts";

const isProduction = import.meta.env.PROD;

const prod = "https://server-black-grass-9418.fly.dev";
const dev = "http://localhost:5228";

export const finalUrl = isProduction ? prod : dev;

export const todoClient = new TodoClient(finalUrl)
