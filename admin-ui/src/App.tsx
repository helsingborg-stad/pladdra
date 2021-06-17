import React, { useEffect, useState } from 'react'
import Amplify, { API, graphqlOperation } from 'aws-amplify'
import { createTodo } from './graphql/mutations'
import { listTodos } from './graphql/queries'

import awsExports from "./aws-exports"
import { Todo } from './API'
Amplify.configure(awsExports)

const initialState = { name: '', description: '' }

const styles: Record<string, React.CSSProperties> = {
	container: { width: 400, margin: '0 auto', display: 'flex', flexDirection: 'column', justifyContent: 'center', padding: 20 },
	todo: {  marginBottom: 15 },
	input: { border: 'none', backgroundColor: '#ddd', marginBottom: 10, padding: 8, fontSize: 18 },
	todoName: { fontSize: 20, fontWeight: 'bold' },
	todoDescription: { marginBottom: 0 },
	button: { backgroundColor: 'black', color: 'white', outline: 'none', fontSize: 18, padding: '12px 0px' },
}

const App = (): React.ReactElement => {
	const [ formState, setFormState ] = useState(initialState)
	const [ todos, setTodos ] = useState<Partial<Todo>[]>([])

	useEffect(() => {
		fetchTodos()
	}, [])

	const setInput = (key: string, value: any) => {
		setFormState({ ...formState, [key]: value })
	}

	const fetchTodos = async () => {
		try {
			const todoData = await API.graphql(graphqlOperation(listTodos)) as Record<string, any>
      
			console.log("data", todoData)
      
			const todos = todoData.data.listTodos.items

      
			setTodos(todos)
		} catch (err) { console.log('error fetching todos', err) }
	}

	const addTodo = async () => {
		try {
			if (!formState.name || !formState.description) return
			const todo = { ...formState }
			setTodos([ ...todos, todo ])
			setFormState(initialState)
			await API.graphql(graphqlOperation(createTodo, {input: todo}))
		} catch (err) {
			console.log('error creating todo:', err)
		}
	}

	return (
		<div style={styles.container}>
			<h2>Amplify Todos</h2>
			<input
				onChange={event => setInput('name', event.target.value)}
				style={styles.input}
				value={formState.name}
				placeholder="Name"
			/>
			<input
				onChange={event => setInput('description', event.target.value)}
				style={styles.input}
				value={formState.description}
				placeholder="Description"
			/>
			<button style={styles.button} onClick={addTodo}>Create Todo</button>
			{
				todos.map((todo, index) => (
					<div key={todo.id ? todo.id : index} style={styles.todo}>
						<p style={styles.todoName}>{todo.name}</p>
						<p style={styles.todoDescription}>{todo.description}</p>
					</div>
				))
			}
		</div>
	)
}



export default App
