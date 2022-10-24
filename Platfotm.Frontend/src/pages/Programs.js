import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getPrograms, reset } from "../features/programs/programsSlice";

const Programs = () => {
  const dispatch = useDispatch();

  const { user } = useSelector((state) => state.reducer.auth);
  const { programs } = useSelector((state) => state.programs);

  useEffect(() => {
    dispatch(getPrograms(user?.data?.token));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token]);

  console.log(programs);
  return (
    <div>
      <h1>Programs</h1>
      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {programs?.data?.map((prg) => {
            return (
              <tr key={prg.id}>
                <td>{prg.title}</td>
                <td style={{ textAlign: "start" }}>{prg.description}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default Programs;
