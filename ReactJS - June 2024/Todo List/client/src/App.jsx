import Footer from "./components/Footer"
import Navigation from "./components/Navigation"
import TodoList from "./components/TodoList"
import './App.css'

function App() {

  return (
    <>
      <Navigation />

      <main className="main">
        <TodoList />
      </main>

      <Footer />

    </>
  )
}

export default App
