import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Students from "./pages/Students";
import Programs from "./pages/Programs";
import Selections from "./pages/Selections";
import NewStudent from "./pages/NewStudent";

function App() {
  return (
    <BrowserRouter>
      <Sidebar>
        <Routes>
          <Route path="/students" element={<Students />} />
          <Route path="/newstudents" element={<NewStudent />} />
          <Route path="/programs" element={<Programs />} />
          <Route path="/selections" element={<Selections />} />
        </Routes>
      </Sidebar>
    </BrowserRouter>
  );
}

export default App;
