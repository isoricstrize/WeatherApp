import { useRouteError, isRouteErrorResponse, Link } from "react-router-dom";
import "../styles/Home.css";

function Error() {
  const error = useRouteError();

  let title = "Something went wrong";
  let message = "An unexpected error occurred.";

  if (error instanceof Error) {
    message = error.message;
  }

  if (isRouteErrorResponse(error)) {
    title = `Error ${error.status}`;
    message = error.statusText;
  }

  return (
    <div className="error-page">
      <h1>{title}</h1>
      <p>{message}</p>

      <div className="error-actions">
        <Link to="/">Go home</Link>
      </div>
    </div>
  );
}

export default Error;
