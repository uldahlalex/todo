import {useEffect, useState} from "react";
import {todoClient} from "./baseUrl.ts";
import type {CreateTodoDto, Todo} from "./generated-ts-client.ts";

function App() {
    
    const [todos, setTodos] = useState<Todo[]>([])
    const [myForm, setMyForm] = useState<CreateTodoDto>({
        description: '',
        priority: 3,
        title: ''
    })
    
    useEffect(() => {
        todoClient.getAllTodos().then(r => {
            setTodos(r)
        })
    }, [])
    

  return (
    <>
        <input value={myForm.title} onChange={e => setMyForm({...myForm, title: e.target.value})} placeholder="your interesting title"/> 
        <input value={myForm.description}  onChange={e => setMyForm({...myForm, description: e.target.value})} placeholder="your amazing description"/> 
        <input value={myForm.priority}  onChange={e => setMyForm({...myForm, priority: Number.parseInt(e.target.value)})} type="number" placeholder="priority"/> 
        <button onClick={() => {
            todoClient.createTodo(myForm).then(result => {
                console.log("hooray that was a success")
                setTodos([...todos, result])
            })
        }}>Create new todo</button>
        
        <hr />
        
        {
            todos.map(t => {
                return <div key={t.id}>
                    <input type="checkbox" checked={t.isdone} onChange={async () => {
                        const result = await todoClient.toggleDone(t);
                        const index = todos.indexOf(t);
                        const duplicate = [...todos];
                        duplicate[index] = result;
                        setTodos(duplicate);
                    }} />
                    {JSON.stringify(t)}
                </div>
            })
        }
    </>
  )
}

export default App
