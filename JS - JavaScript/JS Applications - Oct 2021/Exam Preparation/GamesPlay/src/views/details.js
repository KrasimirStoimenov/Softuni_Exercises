import { createComment, deleteById, getCommentsByGameId, getGameById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (game, isOwner, onDelete,comments,showAddComment, onSubmit) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">${game.summary}</p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
                ${comments.length == 0 
                ? html`<p class="no-comment">No comments.</p>`
                : comments.map(commentCard)}
            </ul>
        </div>

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        ${isOwner ? 
            html`<div class="buttons">
            <a href="/edit/${game._id}" class="button">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
        </div>` : null}
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    ${showAddComment ? 
        html`<article class="create-comment">
                <label>Add new comment:</label>
                <form @submit=${onSubmit} class="form">
                    <textarea name="comment" placeholder="Comment......"></textarea>
                    <input class="btn submit" type="submit" value="Add Comment">
                </form>
                </article>` 
        : null}

</section>`;

const commentCard = (comment)=> html`
<li class="comment">
    <p>Content: ${comment.comment}.</p>
</li>`

export async function detailsPage(ctx) {
    const game = await getGameById(ctx.params.id);
    const userData = getUserData();
    const isOwner = userData && userData.id == game._ownerId;
    const comments = await getCommentsByGameId(game._id);
    const showAddComment = userData != null && !isOwner;
    ctx.render(detailsTemplate(game, isOwner, onDelete, comments,showAddComment,onSubmit));

    async function onSubmit(event){
        event.preventDefault();

        const formData = new FormData(event.target);

        const comment = formData.get('comment').trim();
        const gameId = game._id;
        if(comment == ''){
            return alert('Comment field is required!');
        }

        await createComment({
            gameId,
            comment
          });

          document.querySelector('textarea').value = '';
          ctx.page.redirect(`/details/${game._id}`);
    }

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete that game?');

        if (choice) {
            await deleteById(ctx.params.id);

            ctx.page.redirect('/');
        }
    }
}