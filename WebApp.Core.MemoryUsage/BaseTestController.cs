using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Core.MemoryUsage
{
#if ROUTE
    [ApiController]
    [Route("api/{version}/[controller]")]
#endif
    public abstract class BaseTestController: ControllerBase
    {
#if ROUTE
        [Route("Test/{id}")]
#endif
        [HttpGet]
        public ActionResult<string> Test(int id)
        {
            return $"{nameof(Test)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }
#if ROUTE
        [Route("Search")]
#endif
        [HttpGet]
        public ActionResult<string> Search(string term)
        {
            return $"{nameof(Search)} {this.GetType().Name} {term} - {Guid.NewGuid():N}";
        }
#if ROUTE
        [Route("Count")]
#endif
        [HttpGet]
        public ActionResult<string> Count(string term)
        {
            return $"{nameof(Count)} {this.GetType().Name} {term} - {Guid.NewGuid():N}";
        }
#if ROUTE
        [Route("Get/{id}")]
        [Route("{id}")]
#endif
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            return $"{nameof(Get)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] object payload)
        {
            return $"{nameof(Post)} {this.GetType().Name} {payload} - {Guid.NewGuid():N}";
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] object payload)
        {
            return $"{nameof(Post)} {this.GetType().Name} {payload} - {Guid.NewGuid():N}";
        }

        [HttpPost]
        [HttpPut]
        public ActionResult<string> CreateOrUpdate([FromBody] object payload)
        {
            return $"{nameof(Post)} {this.GetType().Name} {payload} - {Guid.NewGuid():N}";
        }

        [HttpPost]
        [HttpGet]
        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            return $"{nameof(Delete)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }



        [HttpGet]
        public ActionResult<string> Action1(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }


        [HttpGet]
        public ActionResult<string> Action2(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action3(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action4(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action5(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action6(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action7(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action8(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action9(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        public ActionResult<string> Action10(int id)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} - {Guid.NewGuid():N}";
        }


        [HttpPost]
        public ActionResult<string> Action11(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpPost]
        public ActionResult<string> Action12(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action13(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action14(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action15(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action16(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action17(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action18(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
        [HttpPost]
        public ActionResult<string> Action19(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpPost]
        public ActionResult<string> Action20(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }


        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action21(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action22(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action23(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action24(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action25(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action26(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action27(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action28(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action29(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }

        [HttpGet]
        [HttpPost]
        public ActionResult<string> Action30(int id, [FromBody] object payload)
        {
            return $"{nameof(Action1)} {this.GetType().Name} {id} {payload} - {Guid.NewGuid():N}";
        }
    }
}
