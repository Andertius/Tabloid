import { CommandResult } from "./enums/command-result.enum";

export interface CommandResponse<T> {
    result: CommandResult,
    object: T,
    errorMessage: string,
}
