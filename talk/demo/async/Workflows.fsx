
let task1 = async { return 10 + 10 }
let task2 = async { return 20 + 20 }
let p = Async.Parallel [ task1; task2 ]
let result = Async.RunSynchronously p


